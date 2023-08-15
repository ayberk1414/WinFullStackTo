using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WinFullStackTo.Entities;

namespace WinFullStackTo.Forms
{

    public partial class NotesForm : Form
    {
        Product selectedProducts;
        List<Product> products = new List<Product>();
        public string userFullName;
        public NotesForm(string userFullName)
        {
            InitializeComponent();
            var notes = ListProducts();
            Reload();
            this.userFullName = userFullName;
        }

        private void Reload()
        {
            var notes = ListProducts();
            listNote.DataSource = null;
            listNote.DataSource = notes;
            listNote.DisplayMember = "Name";
            listNote.ValueMember = "Id";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Product selectedProduct = listNote.SelectedItem as Product;

            if (selectedProduct != null)
            {
                // Ürünü veritabanından sil
                RemoveProduct(selectedProduct);

                // Listeyi güncelle
                Reload();
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin.");
            }

        }
        private int RemoveProduct(Product product)
        {
            SqlConnection sqlConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Database=TutorialDB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Products WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", product.Id);
            sqlConnection.Open();
            int effectRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectRows;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            selectedProducts = listNote.SelectedItem as Product;
            if (selectedProducts != null)
            {
                lblText.Text = selectedProducts.Stock.ToString();
            }
            lblUser.Text = userFullName;
        }

        // BU METHOD İŞİ NE KAÇ İŞ YAPIYOR
        // 1 iş yapması

        private List<Product> ListProducts()
        {
            var list = new List<Product>();
            SqlConnection sqlConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB; database= TutorialDB; Integrated Security=True;");

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Products";
            sqlConnection.Open();

            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = Convert.ToString(reader["Name"]);
                product.Stock = Convert.ToInt32(reader["Stock"]);
                list.Add(product);
            }


            sqlConnection.Close();
            reader.Close();

            return list;

        }

        private void NoteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void NotesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNote.SelectedItem != null)
            {
                var selectedProduct = listNote.SelectedItem as Product;
                txtStock.Text = selectedProduct.Stock.ToString();
                txtNote.Text = selectedProduct.Name;
                lblText.Text = selectedProduct.Stock.ToString();
            }

        }


        private int AddProduct(Product newProduct)
        {
            SqlConnection sqlConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Database=TutorialDB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Products (Name, Stock) VALUES (@Name, @Stock)";
            cmd.Parameters.AddWithValue("@Name", newProduct.Name);
            cmd.Parameters.AddWithValue("@Stock", newProduct.Stock);
            sqlConnection.Open();
            int effectRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectRows;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtNote.Text;
            int stock;

            if (int.TryParse(txtStock.Text, out stock))
            {
                // Yeni ürün oluştur ve değerleri ata
                Product newProduct = new Product
                {
                    Name = productName,
                    Stock = stock
                };

                // Veritabanına ürünü ekle
                AddProduct(newProduct);

                // Listeyi güncelle ve alanları temizle
                Reload();
                txtNote.Text = "";
                txtStock.Text = "";
            }
            else
            {
                MessageBox.Show("Geçerli bir stok değeri girin.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (selectedProducts != null)
            {
                int newStock;
                if (int.TryParse(txtStock.Text, out newStock))
                {
                    selectedProducts.Name = txtNote.Text;
                    selectedProducts.Stock = newStock;

                    // Ürünü güncelle ve listeyi yeniden yükle
                    UpdateProduct(selectedProducts);
                    Reload();
                }
                else
                {
                    MessageBox.Show("Geçerli bir stok değeri girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir ürün seçin.");
            }
        }

        private int UpdateProduct(Product updateProducts)
        {
            SqlConnection sqlConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Database=TutorialDB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Products SET Name = @Name, Stock = @Stock WHERE ID = @ID ";
            cmd.Parameters.AddWithValue("@Name", updateProducts.Name);
            cmd.Parameters.AddWithValue("@Stock", updateProducts.Stock);
            cmd.Parameters.AddWithValue("@ID", updateProducts.Id);
            sqlConnection.Open();
            int effectRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectRows;
        }
    }
}