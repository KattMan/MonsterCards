using System;
using MonsterLibAbstracts;
using MigraDoc.DocumentObjectModel.Tables;

namespace MonsterPDF.DRPainting
{
    public interface IDRPainter
    {
        void PaintDR(IDamageResist DR, Table drTable);
    }
}
