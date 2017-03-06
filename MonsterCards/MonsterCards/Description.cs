using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Description : Form
    {
        Func<string, string, bool> _ChangeDescription;
        Func<IBook, bool> _ChangeBook;
        IMonster _monster;
        IDataAccess<IBook> _bookDal;

        public Description(Func<string, string, bool> ChangeDescription, Func<IBook, bool> ChangeBook, IMonster monster, IDataAccess<IBook> bookDal)
        {
            InitializeComponent();
            _ChangeDescription = ChangeDescription;
            _ChangeBook = ChangeBook;
            _monster = monster;
            _bookDal = bookDal;
            FillBookCombo();

            txtDescription.Text = _monster.Description;
            txtName.Text = _monster.Name;
            txtPage.Text = _monster.Book.Page;
        }

        private void FillBookCombo()
        {
            var books = _bookDal.LoadData(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data"));
            cboBook.DisplayMember = "Title";
            cboBook.ValueMember = "Title";

            foreach(var book in books)
            {
                cboBook.Items.Add(book);
                if (book.Title == _monster.Book.Title)
                {
                    cboBook.SelectedItem = book;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _monster.Description = txtDescription.Text;
            _monster.Name = txtName.Text;
            _monster.Book.Page = txtPage.Text;
            _monster.Book.Title = ((IBook)cboBook.SelectedItem).Title;
            

            _ChangeDescription(_monster.Description, _monster.Name);
            _ChangeBook(_monster.Book);
            this.Close();
        }
    }
}
