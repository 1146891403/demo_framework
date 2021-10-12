using Demo.WinForm.Entitys;
using Demo.WinForm.Properties;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.WinForm
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            //设置性别下拉列表
            InitializeicbeEdit();
            //设置公司下拉列表
            InitializetllueList();

            //可以代码设置时间  也可以手动将事件绑定到对应控件上
            //tllueListTreeList.CustomDrawNodeImages += new CustomDrawNodeImagesEventHandler(tllueListTreeList_CustomDrawNodeImages);
        }

        public void InitializeicbeEdit()
        {
            //设置下拉列表的值 imageindex 是图片索引
            icbeEdit.Properties.Items.Add("女", "实际值1", 2);
            icbeEdit.Properties.Items.Add("男", "实际值2", 0);
            icbeEdit.Properties.Items.Add("打印机", "实际值3", 1);

            ImageCollection imageCollection = new ImageCollection();
            imageCollection.AddImage(Resources.Mr);//男
            imageCollection.AddImage(Resources.print_16x16);//打印机
            imageCollection.AddImage(Resources.Ms);//女


            icbeEdit.Properties.SmallImages = imageCollection;

        }

        public void InitializetllueList()
        {
            var content = new List<Icbe>
            {
                new Icbe("0", "-1", "公司"),//嵌套级别 0级

                new Icbe("1", "0", "电脑部"),//1级
                new Icbe("2", "0", "机电部"),//
                new Icbe("3", "0", "人事部"),//

                new Icbe("4", "1", "电脑1"),//2级
                new Icbe("5", "1", "电脑2"),

                new Icbe("8", "2", "机电1"),//2级
                new Icbe("9", "2", "机电2"),

                new Icbe("6", "3", "人事1"),//2级
                new Icbe("7", "3", "人事2")
            };

            //节点图片
            ImageCollection imageCollection = new ImageCollection();
            imageCollection.AddImage(Resources.Mr);//男
            imageCollection.AddImage(Resources.Ms);//女
            imageCollection.AddImage(Resources.print_16x16);//打印机
            imageCollection.AddImage(Resources.role_16x16);

            RepositoryItemTreeListLookUpEdit properties = tllueList.Properties;

            properties.ValueMember = "Id";
            properties.DisplayMember = "DisplayName";

            properties.DataSource = content;

            properties.TreeList.KeyFieldName = "Id";
            properties.TreeList.ParentFieldName = "ParentId";
            properties.TreeList.SelectImageList = imageCollection;
        }

        //绘制图片
        private void tllueListTreeList_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            //设置图片索引  就 是 对应的嵌套级别
            e.SelectImageIndex = e.Node.Level;
        }
    }
}
