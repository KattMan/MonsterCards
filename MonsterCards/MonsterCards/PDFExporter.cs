using MonsterDALAbstracts;
using MonsterLibAbstracts;
using MonsterPDFAbstracts;
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
    public partial class PDFExporter : Form
    {
        List<IMonster> _monsters;
        IMonsterCard _monsterCard;
        IDataAccess<IBook> _bookDal;
        List<IMonster> _filteredMonsters;

        public PDFExporter(List<IMonster> monsters, IMonsterCard monsterCard, IDataAccess<IBook> bookDal)
        {
            InitializeComponent();

            _monsters = monsters;
            _monsterCard = monsterCard;
            _bookDal = bookDal;

            LoadSourceBooks();
            FilterList();

            chbResults.DisplayMember = "Name";
            chbResults.ValueMember = "ID";
            chbResults.DataSource = _filteredMonsters;
        }

        public void LoadSourceBooks()
        {
            var books = _bookDal.LoadData(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data"));
            cbSourceBook.DisplayMember = "Title";
            cbSourceBook.ValueMember = "Title";

            cbSourceBook.DataSource = books;

            cbSourceBook.SelectedIndex = 0;
        }

        public void FilterList()
        {
            string selectedBook = cbSourceBook.SelectedValue.ToString();

            if (selectedBook != "")
            {
                _filteredMonsters = _monsters.Where(s => s.Book.Title == selectedBook).OrderBy(s => s.Name).ToList();
            }
            else
            {
                _filteredMonsters = _monsters.OrderBy(s => s.Name).ToList();
            }

            chbResults.DataSource = _filteredMonsters;
            chbResults.DisplayMember = "Name";
            chbResults.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<IMonster> checkedMonsters = new List<IMonster>();
            
            var items = chbResults.CheckedItems;

            foreach(var item in items)
            {
                checkedMonsters.Add((IMonster)item);
            }

            _monsterCard.CreateMonsterCard(checkedMonsters, Directory.GetCurrentDirectory());
        }

        private void cbSourceBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(var x = 0; x < chbResults.Items.Count; x++)
            {
                chbResults.SetItemChecked(x, true);
            }
        }
    }
}
