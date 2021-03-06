﻿using System;
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


namespace MonsterPDF.DRPainting
{
    public class CentaurDR : IDRPainter
    {
        public void PaintDR(IDamageResist DR, Table drTable)
        {
            Row row;
            Paragraph paragraph;

            row = drTable.Rows[0];
            row.Cells[6].MergeRight = 5;
            paragraph = row.Cells[6].AddParagraph();
            if (DR.Winged)
            {
                paragraph.AddText("DR Winged " + DR.BodyType.ToString());
            }
            else
            {
                paragraph.AddText("DR " + DR.BodyType.ToString());
            }

            row.Cells[6].Style = "LabelStatBox";

            row = drTable.Rows[1];

            paragraph = row.Cells[7].AddParagraph();
            paragraph.AddText("Head ");
            row.Cells[7].Style = "LabelStatBox";

            paragraph = row.Cells[8].AddParagraph();
            paragraph.AddText(DR.Head.ToString());
            row.Cells[8].Style = "DataStatBox";

            paragraph = row.Cells[9].AddParagraph();
            paragraph.AddText("Torso ");
            row.Cells[9].Style = "LabelStatBox";

            paragraph = row.Cells[10].AddParagraph();
            paragraph.AddText(DR.Torso.ToString());
            row.Cells[10].Style = "DataStatBox";

            if (DR.Winged)
            {
                paragraph = row.Cells[11].AddParagraph();
                paragraph.AddText("Wings ");
                row.Cells[11].Style = "LabelStatBox";

                paragraph = row.Cells[12].AddParagraph();
                paragraph.AddText(DR.Wing.ToString());
                row.Cells[12].Style = "DataStatBox";
            } 
            
            row = drTable.Rows[2];

            paragraph = row.Cells[7].AddParagraph();
            paragraph.AddText("Arms ");
            row.Cells[7].Style = "LabelStatBox";

            paragraph = row.Cells[8].AddParagraph();
            paragraph.AddText(DR.Arm.ToString());
            row.Cells[8].Style = "DataStatBox";

            paragraph = row.Cells[9].AddParagraph();
            paragraph.AddText("Legs ");
            row.Cells[9].Style = "LabelStatBox";

            paragraph = row.Cells[10].AddParagraph();
            paragraph.AddText(DR.Leg.ToString());
            row.Cells[10].Style = "DataStatBox";

            
            row = drTable.Rows[3];

            paragraph = row.Cells[7].AddParagraph();
            paragraph.AddText("Hands ");
            row.Cells[7].Style = "LabelStatBox";

            paragraph = row.Cells[8].AddParagraph();
            paragraph.AddText(DR.Hand.ToString());
            row.Cells[8].Style = "DataStatBox";

            paragraph = row.Cells[9].AddParagraph();
            paragraph.AddText("Feet ");
            row.Cells[9].Style = "LabelStatBox";

            paragraph = row.Cells[10].AddParagraph();
            paragraph.AddText(DR.Foot.ToString());
            row.Cells[10].Style = "DataStatBox";


















        }
    }
}
