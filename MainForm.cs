using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ComputerComponentsShop
{
    public partial class MainForm : Form
    {
        private List<Component> availableComponents;
        private List<SaleItem> saleItems;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            availableComponents = new List<Component>
            {
                new Component("CPU", "Intel Core i5", "Quad-core processor", 200),
                new Component("GPU", "NVIDIA GeForce GTX 1660", "Graphics card", 300),
                new Component("RAM", "Corsair Vengeance", "8GB DDR4 RAM", 80),
            };

            cmbComponents.DataSource = availableComponents;
            cmbComponents.DisplayMember = "Name";

            saleItems = new List<SaleItem>();
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            if (cmbComponents.SelectedItem != null)
            {
                Component selectedComponent = (Component)cmbComponents.SelectedItem;

                SaleItem saleItem = new SaleItem
                {
                    Component = selectedComponent,
                    Quantity = 1
                };

                saleItems.Add(saleItem);

                UpdateSalesList();

                UpdateTotalCost();
            }
        }

        private void UpdateSalesList()
        {
            lstSales.Items.Clear();

            foreach (var saleItem in saleItems)
            {
                lstSales.Items.Add($"{saleItem.Component.Name} - {saleItem.Component.Price:C} x {saleItem.Quantity}");
            }
        }

        private void UpdateTotalCost()
        {
            decimal totalCost = saleItems.Sum(item => item.Component.Price * item.Quantity);
            lblTotalCost.Text = $"Общая стоимость: {totalCost:C}";
        }

        private void btnOpenComponentsForm_Click(object sender, EventArgs e)
        {
            ComponentsForm componentsForm = new ComponentsForm(availableComponents);
            componentsForm.ShowDialog();
        }
    }
}
