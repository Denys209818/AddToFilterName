using AddElementToFilterName.Entities;
using AddElementToFilterName.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddElementToFilterName
{
    public partial class MainForm : Form
    {
        private EFContext _context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            this._context = new EFContext();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DbSeeder.SeedAll(this._context);
            var filters = GetFIlters();

            FillTreeView(filters);
        }
        private IEnumerable<FilterNameModel> GetFIlters() 
        {
            List<FilterNameModel> nameModels = new List<FilterNameModel>();
            var filterNames = from x in this._context.FilterNames select x;
            var filterNameValue = from x in this._context.FilterNameValues select x;

            var joinedCollection = (from x in filterNames
                                   join filterNameVal in filterNameValue on
             x.Id equals filterNameVal.FilterNameId into joinColl
                      from oneJoinedEL in joinColl
                      select new {
                        FilterName = x.Name,
                        FilterNameId = x.Id,
                        FilterValue = oneJoinedEL.FilterValue != null ? oneJoinedEL.FilterValue : null,
                        FilterValueId = oneJoinedEL.FilterValue != null ? oneJoinedEL.FilterValueId : 0
                      }).AsEnumerable();

            var groupingCollection = from x in joinedCollection
                                     group x by new { x.FilterName, x.FilterNameId } into groupColl
                                     select groupColl;

            foreach (var item in groupingCollection) 
            {
                nameModels.Add(new FilterNameModel { 
                    Id = item.Key.FilterNameId,
                    Name = item.Key.FilterName,
                    Children = item.Select(x => new FilterValueModel 
                    {
                        Name = x.FilterValue.Name,
                        Id = x.FilterValueId
                    }).ToArray()
                });
            }
            return nameModels.ToList();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                if (MessageBox.Show("Ви точно хочете добавити фільтр?", "Програма", 
                    MessageBoxButtons.OKCancel)
                    == DialogResult.OK) 
                {

                    if (_context.FilterNames.SingleOrDefault(x => x.Name.ToLower() ==
                    txtFilter.Text.ToLower()) == null)
                    {
                        var filterName = new FilterName
                        {
                            Name = txtFilter.Text
                        };
                        this._context.FilterNames.Add(filterName);
                        _context.SaveChanges();
                        if (this._context.FilterNameValues
                            .SingleOrDefault(x => x.FilterNameId == filterName.Id &&
                            x.FilterValueId == 0) == null)
                        {
                            this._context.FilterNameValues.Add(new FilterNameValue
                            {
                                FilterNameId = filterName.Id,
                                FilterValueId = 7
                            });
                        }

                        _context.SaveChanges();
                        FillTreeView(GetFIlters());
                    }
                    else 
                    {
                        MessageBox.Show("Фільтр уже існує!");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Заповніть поле!");
            }
        }
        private void FillTreeView(IEnumerable<FilterNameModel> filters) 
        {
            this.tvFilter.Nodes.Clear();
            foreach (var FilterName in filters)
            {
                var node = new TreeNode
                {
                    Name = "ParentTreeNode: " + FilterName.Id.ToString(),
                    Text = FilterName.Name,
                    Tag = FilterName
                };

                foreach (var child in FilterName.Children)
                {
                    node.Nodes.Add(new TreeNode
                    {
                        Name = "ChildTreeNode: " + child.Id.ToString(),
                        Text = child.Name,
                        Tag = child
                    });
                }

                this.tvFilter.Nodes.Add(node);
            }
        }
    }
}
