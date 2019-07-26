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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SLaDE
{
    public partial class frmDocsViewer : Form
    {
        Documentation fullDoc;
        DocCategory selectedCategory;
        DocFunction selectedFunction;

        

        public frmDocsViewer()
        {
            InitializeComponent();
        }

        private void frmDocsViewer_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Constants.DocumentationPath))
            {
                MessageBox.Show("Documentation file not found. Documentation was expected in the file path: \"" + Constants.DocumentationPath + "\". Closing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fullDoc = JsonConvert.DeserializeObject<Documentation>(File.ReadAllText(Constants.DocumentationPath));
            foreach(DocCategory category in fullDoc.Categories)
            {
                cmbCategories.Items.Add(category.CategoryName);
            }

            txtName.TextChanged += TxtName_TextChanged;
            txtExamples.TextChanged += TxtExamples_TextChanged;
        }

        private void TxtExamples_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            Utilities.ImplementSyntaxHighlighting(ref txtExamples, ref e);
        }

        private void TxtName_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            Utilities.ImplementSyntaxHighlighting(ref txtName, ref e);
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFullFunctionList();
        }

        private void SelectSytheLibFuncCategory()
        {
            foreach(var item in cmbCategories.Items)
            {
                if (item.ToString().StartsWith("SytheLib F"))
                {
                    cmbCategories.SelectedItem = item;
                }
            }
        }

        private void PopulateFullFunctionList()
        {
            if (cmbCategories.SelectedIndex < 0) selectedCategory = null;

            lstFunctions.Items.Clear();

            if (cmbCategories.SelectedItem == null) SelectSytheLibFuncCategory();

            DocCategory category = fullDoc.SelectCategoryByName(cmbCategories.SelectedItem.ToString());
            foreach (DocFunction func in category.Functions)
            {
                lstFunctions.Items.Add(func.Name);
            }

            selectedCategory = category;
        }

        private void lstFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                txtName.Text = "";
                txtDesc.Text = "";
                txtExamples.Text = "";

                DocFunction func = selectedCategory.SelectFunctionByName(lstFunctions.SelectedItem.ToString());
                txtDesc.Text = func.Description;
                txtName.Text = func.Name;
                txtExamples.Text = func.Examples;

                selectedFunction = func;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            lstFunctions.Items.Clear();
            lstFunctions.Enabled = false;
            if (txtFilter.Text == "") PopulateFullFunctionList();
            else
            {
                foreach(DocFunction func in selectedCategory.FilterFunctions(txtFilter.Text))
                {
                    lstFunctions.Items.Add(func.Name);
                }
            }

            lstFunctions.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFunction.Description = txtDesc.Text;
                selectedFunction.Examples = txtExamples.Text;

                fullDoc.EditFunction(selectedFunction);

                File.WriteAllText(Constants.DocumentationPath, JsonConvert.SerializeObject(fullDoc));
                Application.DoEvents();

                cmbCategories.Items.Clear();
                foreach (DocCategory category in fullDoc.Categories)
                {
                    cmbCategories.Items.Add(category.CategoryName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Changes successfully saved to \"" + Constants.DocumentationPath + "\"", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
