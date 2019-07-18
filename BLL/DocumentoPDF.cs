using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DAL;
using ENTITY;
namespace BLL
{
    public class DocumentoPDF
    {
        PersonaRepository personaRepositorio;
        string ruta = @"Reporte.pdf";

        public DocumentoPDF()
        {
            personaRepositorio = new PersonaRepository();
        }


        public void GuardarPDF()
        {
            List<Persona> personas = personaRepositorio.Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER.Rotate(), 40, 40, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            document.Add(new Paragraph("REPORTE PULSACIONES"));
            document.Add(new Paragraph("\n"));
            document.Add(PintarTabla(personas));

            document.Close();
        }

        public PdfPTable PintarTabla(List<Persona> personas)
        {
            PdfPTable tabla = new PdfPTable(5);

            tabla.AddCell(new Paragraph("IDENTIFICACIÓN"));
            tabla.AddCell(new Paragraph("NOMBRE"));
            tabla.AddCell(new Paragraph("EDAD"));
            tabla.AddCell(new Paragraph("SEXO"));
            tabla.AddCell(new Paragraph("PULSACIÓN"));

            foreach (var item in personas)
            {
                tabla.AddCell(item.Identificacion);
                tabla.AddCell(item.Nombre);
                tabla.AddCell($"{item.Edad}");
                tabla.AddCell(item.Sexo);
                tabla.AddCell($"{item.Pulsaciones}");
            }
            return tabla;
        }

    }
}
