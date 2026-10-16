namespace Frcistan;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        grpProduct = new GroupBox();
        btnClear = new Button();
        btnDelete = new Button();
        btnUpdate = new Button();
        btnAdd = new Button();
        numPrice = new NumericUpDown();
        lblPrice = new Label();
        numQuantity = new NumericUpDown();
        lblQuantity = new Label();
        txtName = new TextBox();
        lblName = new Label();
        txtSku = new TextBox();
        lblSku = new Label();
        cmbBrand = new ComboBox();
        lblBrand = new Label();
        lblSearch = new Label();
        txtSearch = new TextBox();
        dgvProducts = new DataGridView();
        lblSortInfo = new Label();
        lblCount = new Label();
        grpProduct.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        SuspendLayout();
        //
        // grpProduct
        //
        grpProduct.Controls.Add(btnClear);
        grpProduct.Controls.Add(btnDelete);
        grpProduct.Controls.Add(btnUpdate);
        grpProduct.Controls.Add(btnAdd);
        grpProduct.Controls.Add(numPrice);
        grpProduct.Controls.Add(lblPrice);
        grpProduct.Controls.Add(numQuantity);
        grpProduct.Controls.Add(lblQuantity);
        grpProduct.Controls.Add(txtName);
        grpProduct.Controls.Add(lblName);
        grpProduct.Controls.Add(txtSku);
        grpProduct.Controls.Add(lblSku);
        grpProduct.Controls.Add(cmbBrand);
        grpProduct.Controls.Add(lblBrand);
        grpProduct.Location = new Point(12, 12);
        grpProduct.Name = "grpProduct";
        grpProduct.Size = new Size(290, 300);
        grpProduct.TabIndex = 0;
        grpProduct.TabStop = false;
        grpProduct.Text = "Ürün Bilgileri";
        //
        // lblBrand
        //
        lblBrand.AutoSize = true;
        lblBrand.Location = new Point(15, 32);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(43, 15);
        lblBrand.TabIndex = 0;
        lblBrand.Text = "Marka:";
        //
        // cmbBrand
        //
        cmbBrand.FormattingEnabled = true;
        cmbBrand.Items.AddRange(new object[] { "AndyMark", "REV Robotics", "Swerve Drive Specialties", "WCP" });
        cmbBrand.Location = new Point(95, 29);
        cmbBrand.Name = "cmbBrand";
        cmbBrand.Size = new Size(180, 23);
        cmbBrand.TabIndex = 1;
        //
        // lblSku
        //
        lblSku.AutoSize = true;
        lblSku.Location = new Point(15, 67);
        lblSku.Name = "lblSku";
        lblSku.Size = new Size(31, 15);
        lblSku.TabIndex = 2;
        lblSku.Text = "SKU:";
        //
        // txtSku
        //
        txtSku.Location = new Point(95, 64);
        txtSku.MaxLength = 50;
        txtSku.Name = "txtSku";
        txtSku.Size = new Size(180, 23);
        txtSku.TabIndex = 3;
        //
        // lblName
        //
        lblName.AutoSize = true;
        lblName.Location = new Point(15, 102);
        lblName.Name = "lblName";
        lblName.Size = new Size(57, 15);
        lblName.TabIndex = 4;
        lblName.Text = "Ürün Adı:";
        //
        // txtName
        //
        txtName.Location = new Point(95, 99);
        txtName.MaxLength = 100;
        txtName.Name = "txtName";
        txtName.Size = new Size(180, 23);
        txtName.TabIndex = 5;
        //
        // lblQuantity
        //
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(15, 137);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(34, 15);
        lblQuantity.TabIndex = 6;
        lblQuantity.Text = "Adet:";
        //
        // numQuantity
        //
        numQuantity.Location = new Point(95, 135);
        numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new Size(100, 23);
        numQuantity.TabIndex = 7;
        //
        // lblPrice
        //
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(15, 172);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(62, 15);
        lblPrice.TabIndex = 8;
        lblPrice.Text = "Fiyat (TL):";
        //
        // numPrice
        //
        numPrice.DecimalPlaces = 2;
        numPrice.Location = new Point(95, 170);
        numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPrice.Name = "numPrice";
        numPrice.Size = new Size(100, 23);
        numPrice.TabIndex = 9;
        numPrice.ThousandsSeparator = true;
        //
        // btnAdd
        //
        btnAdd.Location = new Point(15, 215);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(125, 30);
        btnAdd.TabIndex = 10;
        btnAdd.Text = "Ekle";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // btnUpdate
        //
        btnUpdate.Location = new Point(150, 215);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(125, 30);
        btnUpdate.TabIndex = 11;
        btnUpdate.Text = "Güncelle";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnDelete
        //
        btnDelete.Location = new Point(15, 255);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(125, 30);
        btnDelete.TabIndex = 12;
        btnDelete.Text = "Sil";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnClear
        //
        btnClear.Location = new Point(150, 255);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(125, 30);
        btnClear.TabIndex = 13;
        btnClear.Text = "Temizle";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(320, 20);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(28, 15);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Ara:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(355, 17);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Marka, SKU veya ürün adı";
        txtSearch.Size = new Size(250, 23);
        txtSearch.TabIndex = 2;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // lblSortInfo
        //
        lblSortInfo.AutoSize = true;
        lblSortInfo.ForeColor = SystemColors.GrayText;
        lblSortInfo.Location = new Point(620, 20);
        lblSortInfo.Name = "lblSortInfo";
        lblSortInfo.Size = new Size(226, 15);
        lblSortInfo.TabIndex = 3;
        lblSortInfo.Text = "Sıralamak için sütun başlığına tıklayın.";
        //
        // dgvProducts
        //
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.BackgroundColor = SystemColors.Window;
        dgvProducts.Location = new Point(320, 50);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(560, 262);
        dgvProducts.TabIndex = 4;
        dgvProducts.CellClick += dgvProducts_CellClick;
        dgvProducts.DataBindingComplete += dgvProducts_DataBindingComplete;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Location = new Point(320, 320);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(84, 15);
        lblCount.TabIndex = 5;
        lblCount.Text = "Toplam ürün: 0";
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(894, 346);
        Controls.Add(lblCount);
        Controls.Add(dgvProducts);
        Controls.Add(lblSortInfo);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
        Controls.Add(grpProduct);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Frcistan 0.1 - Robot Parçası Stok Takibi";
        Load += Form1_Load;
        grpProduct.ResumeLayout(false);
        grpProduct.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpProduct;
    private Label lblBrand;
    private ComboBox cmbBrand;
    private Label lblSku;
    private TextBox txtSku;
    private Label lblName;
    private TextBox txtName;
    private Label lblQuantity;
    private NumericUpDown numQuantity;
    private Label lblPrice;
    private NumericUpDown numPrice;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private Label lblSearch;
    private TextBox txtSearch;
    private DataGridView dgvProducts;
    private Label lblSortInfo;
    private Label lblCount;
}
