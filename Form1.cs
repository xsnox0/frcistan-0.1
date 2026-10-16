using MySql.Data.MySqlClient;

namespace Frcistan;

public partial class Form1 : Form
{
    // Listeden seçilen ürünün Id'si. Seçim yoksa -1.
    private int selectedId = -1;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            Database.CreateIfNotExists();
            LoadProducts();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Veritabanına bağlanılamadı. XAMPP'ta MySQL'in çalıştığından emin olun.\n\n" + ex.Message,
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadProducts()
    {
        dgvProducts.DataSource = Database.GetProducts(txtSearch.Text.Trim());

        dgvProducts.Columns["Id"].Visible = false;
        dgvProducts.Columns["Brand"].HeaderText = "Marka";
        dgvProducts.Columns["Sku"].HeaderText = "SKU";
        dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
        dgvProducts.Columns["Quantity"].HeaderText = "Adet";
        dgvProducts.Columns["Price"].HeaderText = "Fiyat (TL)";
        dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N2";
        dgvProducts.Columns["Name"].FillWeight = 200;   // ürün adı sütunu daha geniş olsun

        lblCount.Text = "Toplam ürün: " + dgvProducts.Rows.Count;
    }

    private bool CheckInputs()
    {
        if (cmbBrand.Text.Trim() == "" || txtSku.Text.Trim() == "" || txtName.Text.Trim() == "")
        {
            MessageBox.Show("Marka, SKU ve ürün adı boş bırakılamaz.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!CheckInputs())
            return;

        // SKU'yu büyük harfe çeviriyoruz ki "am-4258a" ile "AM-4258A" aynı sayılsın.
        // ToUpper() değil ToUpperInvariant(): Türkçe Windows'ta "i" harfi "İ" olmasın diye.
        string sku = txtSku.Text.Trim().ToUpperInvariant();

        try
        {
            int existingId = Database.FindIdBySku(sku);
            if (existingId != -1)
            {
                DialogResult answer = MessageBox.Show(
                    "Bu SKU zaten kayıtlı.\nGirdiğiniz adet mevcut stoğa eklensin mi?",
                    "Aynı ürün var", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    Database.AddStock(existingId, (int)numQuantity.Value);
                    LoadProducts();
                    ClearForm();
                }
                return;
            }

            Database.Add(cmbBrand.Text.Trim(), sku, txtName.Text.Trim(), (int)numQuantity.Value, numPrice.Value);
            LoadProducts();
            ClearForm();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Kayıt eklenemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (selectedId == -1)
        {
            MessageBox.Show("Önce listeden bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!CheckInputs())
            return;

        string sku = txtSku.Text.Trim().ToUpperInvariant();

        try
        {
            Database.Update(selectedId, cmbBrand.Text.Trim(), sku, txtName.Text.Trim(), (int)numQuantity.Value, numPrice.Value);
            LoadProducts();
            ClearForm();
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            // 1062: UNIQUE kuralı ihlali, yani bu SKU başka bir üründe var.
            MessageBox.Show("Bu SKU başka bir ürüne ait.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Kayıt güncellenemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (selectedId == -1)
        {
            MessageBox.Show("Önce listeden bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult answer = MessageBox.Show(txtName.Text + " silinsin mi?", "Silme Onayı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        try
        {
            Database.Delete(selectedId);
            LoadProducts();
            ClearForm();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Kayıt silinemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            LoadProducts();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Arama yapılamadı.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Liste yüklenince ilk satır otomatik seçili gelmesin.
    private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        dgvProducts.ClearSelection();
    }

    // Tablodan bir satır seçilince bilgileri kutulara doldurur.
    private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
        selectedId = Convert.ToInt32(row.Cells["Id"].Value);
        cmbBrand.Text = row.Cells["Brand"].Value.ToString();
        txtSku.Text = row.Cells["Sku"].Value.ToString();
        txtName.Text = row.Cells["Name"].Value.ToString();
        numQuantity.Value = Convert.ToInt32(row.Cells["Quantity"].Value);
        numPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
    }

    private void ClearForm()
    {
        selectedId = -1;
        cmbBrand.Text = "";
        txtSku.Clear();
        txtName.Clear();
        numQuantity.Value = 0;
        numPrice.Value = 0;
        dgvProducts.ClearSelection();
        txtSku.Focus();
    }
}
