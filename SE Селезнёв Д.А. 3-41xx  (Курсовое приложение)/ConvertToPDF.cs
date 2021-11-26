using iTextSharp.text;
using iTextSharp.text.pdf;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    public class ConvertToPDF
    {
        public static void ConcertInfoPDF(string path, ReportModel data, string month)
        {
            var doc1 = new Document(PageSize.A4);
            
            var streamObj = new System.IO.FileStream(path, System.IO.FileMode.Create);
            BaseFont font = BaseFont.CreateFont(Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\calibri.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font head = new Font(font, 22f, Font.BOLD, BaseColor.BLACK);
            Font def = new Font(font, 16f, Font.NORMAL, BaseColor.BLACK);
            Font def2 = new Font(font, 16f, Font.BOLD, BaseColor.BLACK);
            PdfWriter writer = PdfWriter.GetInstance(doc1, streamObj);
            doc1.Open();
            PdfContentByte cb = writer.DirectContent;

            
            cb.RoundRectangle(20f, 688f, 550f, 110f, 20f);
            cb.Stroke();

            doc1.Add(new Paragraph("Отчет за " + month, head));
            doc1.Add(new Paragraph("Всего добавленных мероприятий: " + data.NumLikeEvents, def));
            doc1.Add(new Paragraph("Ваша любимая категория в этом месяце: " + data.LikeUserCategory, def));
            doc1.Add(new Paragraph("Ваш любимый тип мероприятий в этом месяце: " + data.LikeUserType.ToLower(), def));
          
            foreach (var e in data.LikeUserEvents)
            {
                doc1.NewPage();

                cb.RoundRectangle(20f, 50f, 550f, 748f, 20f);
                cb.Stroke();

                doc1.Add(new Paragraph("Ваши прошедшие мероприятия:", head));
                doc1.Add(new Paragraph("Название:", def2));
                doc1.Add(new Paragraph(e.Title + " " + e.Ages.Age + "+", def));
                doc1.Add(new Paragraph("Дата провидения:", def2));
                doc1.Add(new Paragraph(e.CurSession.Date.ToString("d"), def));
                doc1.Add(new Paragraph("Место провидения:", def2));
                doc1.Add(new Paragraph(e.CurSession.Organizer.Place.City.Name + "\n" + e.CurSession.Organizer.Name + "\n" + e.CurSession.Organizer.Place.Address, def));
                doc1.Add(new Paragraph("Описание:", def2));
                doc1.Add(new Paragraph(e.Description, def));
            }
            doc1.Close();
        }
    }
}
