using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MonsterLibAbstracts;
using MonsterLibAbstracts.AttackTypes;
using MonsterPDFAbstracts;
using MonsterPDF.DRPainting;

namespace MonsterPDF
{
    public class MonsterCard : IMonsterCard
    {
        Document _document;

        public void CreateMonsterCard(List<IMonster> monsterInfoList, string path)
        {
            CreateDocument();
            CreateStyles();
            foreach (var monsterInfo in monsterInfoList)
            {
                CreateNewSection();
                CreateNameArea(monsterInfo);
                CreateDescriptionArea(monsterInfo);
                CreateStatsArea(monsterInfo, monsterInfo.Stats);

                CreateTraitsArea(monsterInfo.Traits);
                CreateSkillsArea(monsterInfo.Skills);
                CreateTacticsArea(monsterInfo.Classification.Description, monsterInfo.Tactics);
                CreateDropsArea(monsterInfo.Drops);

                if (monsterInfo.Attacks.Melee.Any()) MeleeAttacksArea(monsterInfo.Attacks.Melee);
                if (monsterInfo.Attacks.Ranged.Any()) RangedAttacksArea(monsterInfo.Attacks.Ranged);
                if (monsterInfo.Attacks.Spell.Any()) SpellAttacksArea(monsterInfo.Attacks.Spell);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.None);
            renderer.Document = _document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path.Combine(path, "MonsterCards.pdf"));
        }

        private void CreateDocument()
        {
            _document = new Document();
            _document.DefaultPageSetup.PageHeight = Unit.FromInch(4.0);
            _document.DefaultPageSetup.PageWidth = Unit.FromInch(6.0);
            _document.DefaultPageSetup.TopMargin = Unit.FromCentimeter(0.5);
            _document.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(0.5);
            _document.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(0.5);
            _document.DefaultPageSetup.RightMargin = Unit.FromCentimeter(0.5);
        }

        private void CreateNewSection()
        {
            var section = _document.AddSection();
            section.PageSetup = _document.DefaultPageSetup.Clone();
        }

        private void CreateStyles()
        {
            Style style;

            style = _document.Styles.AddStyle("LabelTextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.ParagraphFormat.Borders.Distance = 2;
            style.ParagraphFormat.Font.Size = Unit.FromPoint(10);
            style.ParagraphFormat.Font.Bold = true;

            style = _document.Styles.AddStyle("DataTextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.ParagraphFormat.Borders.Width = 1;
            style.ParagraphFormat.Borders.Distance = 1;
            style.ParagraphFormat.Shading.Color = Colors.Cornsilk;
            style.ParagraphFormat.Borders.Color = Colors.Black;
            style.ParagraphFormat.Font.Size = Unit.FromPoint(10);

            style = _document.Styles.AddStyle("LabelStatBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.ParagraphFormat.Borders.Distance = 2;
            style.ParagraphFormat.Font.Size = Unit.FromPoint(6);
            style.ParagraphFormat.Font.Bold = true;

            style = _document.Styles.AddStyle("DataStatBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.ParagraphFormat.Borders.Width = 1;
            style.ParagraphFormat.Borders.Distance = 1;
            style.ParagraphFormat.Shading.Color = Colors.Cornsilk;
            style.ParagraphFormat.Borders.Color = Colors.Black;
            style.ParagraphFormat.Font.Size = Unit.FromPoint(6);

            style = _document.Styles.AddStyle("ReferenceBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            //style.ParagraphFormat.Borders.Width = 1;
            //style.ParagraphFormat.Borders.Distance = 1;
            //style.ParagraphFormat.Shading.Color = Colors.Cornsilk;
            //style.ParagraphFormat.Borders.Color = Colors.Black;
            style.ParagraphFormat.Font.Size = Unit.FromPoint(8);
        }

        private void CreateNameArea(IMonster monsterInfo)
        {
            var section = _document.LastSection;

            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var table = section.AddTable();
            table.AddColumn().Width = PageWidth * 0.6;
            table.AddColumn().Width = PageWidth * 0.4;
            var row = table.AddRow();


            var paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "DataTextBox";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = Unit.FromPoint(14);
            paragraph.AddText(monsterInfo.Name);

            paragraph = row.Cells[1].AddParagraph();
            paragraph.Style = "ReferenceBox";
            if (!string.IsNullOrEmpty(monsterInfo.Book.Title))
            {
                paragraph.AddText(monsterInfo.Book.Title);
            }
            if (!string.IsNullOrEmpty(monsterInfo.Book.Page))
            {
                paragraph.AddText(" p." + monsterInfo.Book.Page);
            }
        }

        private void CreateClassArea(IMonster monsterInfo)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.20;
            table.AddColumn().Width = PageWidth * 0.08;
            table.AddColumn().Width = PageWidth * 0.15;
            table.AddColumn().Width = PageWidth * 0.09;
            table.AddColumn().Width = PageWidth * 0.42;

            var row = table.AddRow();


            var paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("Class: ");
            row.Cells[0].Style = "LabelStatBox";

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText(monsterInfo.Classification.Name);
            row.Cells[1].Style = "DataStatBox";

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Weight: ");
            row.Cells[2].Style = "LabelStatBox";

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddFormattedText(monsterInfo.Stats.Weight);
            row.Cells[3].Style = "DataStatBox";

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddFormattedText("Habitats: ");
            row.Cells[4].Style = "LabelStatBox";

            paragraph = row.Cells[5].AddParagraph();
            monsterInfo.Habitats.Sort();
            paragraph.AddFormattedText(string.Join(",", monsterInfo.Habitats));
            row.Cells[5].Style = "DataStatBox";


        }

        private void CreateDescriptionArea(IMonster monsterInfo)
        {
            var section = _document.LastSection;

            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var table = section.AddTable();
            table.AddColumn().Width = PageWidth;
            var row = table.AddRow();


            var paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "DataTextBox";
            paragraph.AddText(monsterInfo.Description);

        }

        private void CreateStatsArea(IMonster monsterInfo, IStats stats)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.05;
            table.AddColumn().Width = PageWidth * 0.05;
            table.AddColumn().Width = PageWidth * 0.05;
            table.AddColumn().Width = PageWidth * 0.05;
            table.AddColumn().Width = PageWidth * 0.07;
            table.AddColumn().Width = PageWidth * 0.06;

            table.AddColumn().Width = PageWidth * 0.01;
            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.04;
            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.04;
            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.04;

            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.26;


            Row row;
            Paragraph paragraph;

            row = table.AddRow();

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("ST ");
            row.Cells[0].Style = "LabelStatBox";

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText(stats.Strength.ToString());
            row.Cells[1].Style = "DataStatBox";

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("HP ");
            row.Cells[2].Style = "LabelStatBox";

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText(stats.HitPoints.ToString());
            row.Cells[3].Style = "DataStatBox";

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Speed ");
            row.Cells[4].Style = "LabelStatBox";

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText(stats.Speed.ToString());
            row.Cells[5].Style = "DataStatBox";

            paragraph = row.Cells[13].AddParagraph();
            paragraph.AddText("Class:");
            row.Cells[13].Style = "LabelStatBox";

            paragraph = row.Cells[14].AddParagraph();
            paragraph.AddText(monsterInfo.Classification.Name);
            row.Cells[14].Style = "DataStatBox";

            row = table.AddRow();

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("DX ");
            row.Cells[0].Style = "LabelStatBox";

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText(stats.Dexterity.ToString());
            row.Cells[1].Style = "DataStatBox";

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("FP ");
            row.Cells[2].Style = "LabelStatBox";

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText(stats.FatiguePoints.ToString());
            row.Cells[3].Style = "DataStatBox";

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Move ");
            row.Cells[4].Style = "LabelStatBox";

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText(stats.Move.ToString());
            row.Cells[5].Style = "DataStatBox";

            paragraph = row.Cells[13].AddParagraph();
            paragraph.AddText("Weight:");
            row.Cells[13].Style = "LabelStatBox";

            paragraph = row.Cells[14].AddParagraph();
            paragraph.AddText(stats.Weight);
            row.Cells[14].Style = "DataStatBox";

            row = table.AddRow();

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("IQ ");
            row.Cells[0].Style = "LabelStatBox";

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText(stats.IQ.ToString());
            row.Cells[1].Style = "DataStatBox";

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("Will ");
            row.Cells[2].Style = "LabelStatBox";

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText(stats.Will.ToString());
            row.Cells[3].Style = "DataStatBox";

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Dodge ");
            row.Cells[4].Style = "LabelStatBox";

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText(stats.Dodge.ToString());
            row.Cells[5].Style = "DataStatBox";

            paragraph = row.Cells[13].AddParagraph();
            paragraph.AddText("Habitats:");
            row.Cells[13].Style = "LabelStatBox";

            paragraph = row.Cells[14].AddParagraph();
            paragraph.AddText(string.Join(", ", monsterInfo.Habitats.OrderBy(s => s.Name).Select(s => s.Name)));
            row.Cells[14].Style = "DataStatBox";
            row.Cells[14].MergeDown = 1;

            row = table.AddRow();

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("HT ");
            row.Cells[0].Style = "LabelStatBox";

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText(stats.Health.ToString());
            row.Cells[1].Style = "DataStatBox";

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("Per ");
            row.Cells[2].Style = "LabelStatBox";

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText(stats.Perception);
            row.Cells[3].Style = "DataStatBox";

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("SM ");
            row.Cells[4].Style = "LabelStatBox";

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText(stats.SizeModifier.ToString());
            row.Cells[5].Style = "DataStatBox";

            CreateDRArea(monsterInfo.DamageResist, table);
        }

        private void CreateDRArea(IDamageResist DR, Table drTable)
        {
            IDRPainter drPainter = null;

            switch(DR.BodyType)
            {
                case BodyType.Arachnoid:
                    drPainter = new ArachnoidDR();
                    break;
                case BodyType.Avian:
                    drPainter = new AvianDR();
                    break;
                case BodyType.Cancroid:
                    drPainter = new CancroidDR();
                    break;
                case BodyType.Centaur:
                    drPainter = new CentaurDR();
                    break;
                case BodyType.Hexapod:
                    drPainter = new HexapodDR();
                    break;
                case BodyType.Humanoid:
                    drPainter = new HumanoidDR();
                    break;
                case BodyType.Ichthyoid:
                    drPainter = new IchthyoidDR();
                    break;
                case BodyType.Octopod:
                    drPainter = new OctopodDR();
                    break;
                case BodyType.Quadruped:
                    drPainter = new QuadrupedDR();
                    break;
                case BodyType.Vermiform:
                    drPainter = new VermiformDR();
                    break;
                case BodyType.Hybrid:
                    drPainter = new HybridDR();
                    break;
            }
            if (drPainter != null)
            {
                drPainter.PaintDR(DR, drTable);
            }
        }

        private void CreateTraitsArea(List<ITrait> Traits)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.90;

            Row row;

            row = table.AddRow();
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.AddText("Traits:");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.Style = "DataStatBox";
            paragraph.AddText(string.Join(", ", Traits.OrderBy(s => s.Name).Select(s => s.Name)));

        }

        private void CreateSkillsArea(List<ISkill> Skills)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.90;

            Row row;

            row = table.AddRow();
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.AddText("Skills:");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.Style = "DataStatBox";
            paragraph.AddText(string.Join(", ", Skills.OrderBy(s => s.Name).Select(s => s.Name)));

        }

        private void CreateTacticsArea(string ClassText, List<ITactic> Tactics)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.90;

            Row row;

            row = table.AddRow();
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.AddText("Tactics:");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.Style = "DataStatBox";
            var fullText = ClassText + "\r\n" + string.Join("\r\n", Tactics.OrderBy(s => s.Order).Select(s => s.Text));
            paragraph.AddText(fullText);

        }

        private void CreateDropsArea(List<IDrop> Drops)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.90;

            Row row;

            row = table.AddRow();
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.AddText("Drops:");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.Style = "DataStatBox";
            paragraph.AddText(string.Join(", ", Drops.OrderBy(s => s.Name).Select(s => s.Name)));

        }

        private void MeleeAttacksArea(List<IMelee> Attacks)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.26;
            table.AddColumn().Width = PageWidth * 0.20;
            table.AddColumn().Width = PageWidth * 0.08;
            table.AddColumn().Width = PageWidth * 0.08;
            table.AddColumn().Width = PageWidth * 0.08;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.12;
            table.AddColumn().Width = PageWidth * 0.08;

            Row row;

            row = table.AddRow();
            row.Cells[0].MergeRight = 7;
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.Format.Font.Size = 9;
            paragraph.AddText("Melee Attacks");

            row = table.AddRow();
            row.Style = "LabelStatBox";

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("Weapon");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText("Usage");

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("Skill");

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText("Parry");

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Block");

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText("Damage");

            paragraph = row.Cells[6].AddParagraph();
            paragraph.AddText("Type");

            paragraph = row.Cells[7].AddParagraph();
            paragraph.AddText("Reach");


            foreach (var attack in Attacks.OrderBy(s => s.Weapon))
            {

                row = table.AddRow();
                row.Style = "DataStatBox";

                paragraph = row.Cells[0].AddParagraph();
                paragraph.AddText(attack.Weapon);

                paragraph = row.Cells[1].AddParagraph();
                paragraph.AddText(attack.Usage);

                paragraph = row.Cells[2].AddParagraph();
                paragraph.AddText(attack.Skill);

                paragraph = row.Cells[3].AddParagraph();
                paragraph.AddText(attack.Parry);

                paragraph = row.Cells[4].AddParagraph();
                paragraph.AddText(attack.Block);

                paragraph = row.Cells[5].AddParagraph();
                paragraph.AddText(attack.Damage);

                paragraph = row.Cells[6].AddParagraph();
                paragraph.AddText(attack.DamageType);

                paragraph = row.Cells[7].AddParagraph();
                paragraph.AddText(attack.Reach);

            }
        }

        private void RangedAttacksArea(List<IRanged> Attacks)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.26;
            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.08;
            table.AddColumn().Width = PageWidth * 0.06;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.12;
            table.AddColumn().Width = PageWidth * 0.12;
            table.AddColumn().Width = PageWidth * 0.12;
            table.AddColumn().Width = PageWidth * 0.08;

            Row row;

            row = table.AddRow();
            row.Cells[0].MergeRight = 8;
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.Format.Font.Size = 9;
            paragraph.AddText("Ranged Attacks");

            row = table.AddRow();
            row.Style = "LabelStatBox";

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("Weapon");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText("ROF");

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("Reload");

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText("Skill");

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Damage");

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText("Type");

            paragraph = row.Cells[6].AddParagraph();
            paragraph.AddText("1/2 Dmg");

            paragraph = row.Cells[7].AddParagraph();
            paragraph.AddText("Max Rng");

            paragraph = row.Cells[8].AddParagraph();
            paragraph.AddText("Bulk");


            foreach (var attack in Attacks.OrderBy(s => s.Weapon))
            {
                row = table.AddRow();
                row.Style = "DataStatBox";

                paragraph = row.Cells[0].AddParagraph();
                paragraph.AddText(attack.Weapon);

                paragraph = row.Cells[1].AddParagraph();
                paragraph.AddText(attack.ROF);

                paragraph = row.Cells[2].AddParagraph();
                paragraph.AddText(attack.Reload);

                paragraph = row.Cells[3].AddParagraph();
                paragraph.AddText(attack.Skill);

                paragraph = row.Cells[4].AddParagraph();
                paragraph.AddText(attack.Damage);

                paragraph = row.Cells[5].AddParagraph();
                paragraph.AddText(attack.DamageType);

                paragraph = row.Cells[6].AddParagraph();
                paragraph.AddText(attack.HalfDmg);

                paragraph = row.Cells[7].AddParagraph();
                paragraph.AddText(attack.MaxRange);

                paragraph = row.Cells[8].AddParagraph();
                paragraph.AddText(attack.Bulk);
            }
        }

        private void SpellAttacksArea(List<ISpell> Attacks)
        {
            var PageWidth = _document.DefaultPageSetup.PageWidth - _document.DefaultPageSetup.LeftMargin - _document.DefaultPageSetup.RightMargin;
            var section = _document.LastSection;
            Paragraph paragraph;

            var table = section.AddTable();

            table.AddColumn().Width = PageWidth * 0.40;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.10;
            table.AddColumn().Width = PageWidth * 0.10;

            Row row;

            row = table.AddRow();
            row.Cells[0].MergeRight = 5;
            paragraph = row.Cells[0].AddParagraph();
            paragraph.Style = "LabelStatBox";
            paragraph.Format.Font.Size = 9;
            paragraph.AddText("Spells");

            row = table.AddRow();
            row.Style = "LabelStatBox";

            paragraph = row.Cells[0].AddParagraph();
            paragraph.AddText("Spell");

            paragraph = row.Cells[1].AddParagraph();
            paragraph.AddText("Skill");

            paragraph = row.Cells[2].AddParagraph();
            paragraph.AddText("Cost");

            paragraph = row.Cells[3].AddParagraph();
            paragraph.AddText("Time");

            paragraph = row.Cells[4].AddParagraph();
            paragraph.AddText("Duration");

            paragraph = row.Cells[5].AddParagraph();
            paragraph.AddText("Maintain");

            foreach (var attack in Attacks.OrderBy(s => s.Name))
            {
                row = table.AddRow();
                row.Style = "DataStatBox";

                paragraph = row.Cells[0].AddParagraph();
                paragraph.AddText(attack.Name);

                paragraph = row.Cells[1].AddParagraph();
                paragraph.AddText(attack.Skill);

                paragraph = row.Cells[2].AddParagraph();
                paragraph.AddText(attack.Cost);

                paragraph = row.Cells[3].AddParagraph();
                paragraph.AddText(attack.TimeToCast);

                paragraph = row.Cells[4].AddParagraph();
                paragraph.AddText(attack.Duration);

                paragraph = row.Cells[5].AddParagraph();
                paragraph.AddText(attack.Maintain);
            }
        }
    }
}
