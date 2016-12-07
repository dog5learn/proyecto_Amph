using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using Microsoft.SqlServer;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Generar PDF del proyecto
        private void radButton1_Click(object sender, EventArgs e)
        {
            //Se crea un nuevo documento
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            
            //Se escribe en el PDF
            PdfWriter escritura = PdfWriter.GetInstance(doc, new FileStream("PDFprueba.pdf", FileMode.Create));

            //Se abre el documento para escribir
            doc.Open();

            //Se creara primero la imagen del logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("LogoAmphenol.png");
            //Para que la imagen este en central
            logo.ScaleAbsolute(500f, 90f);
            logo.Alignment = 1;
            doc.Add(logo);

            //Para agregar texto en central, en negritas
            var Negritas = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Paragraph parrafonegrito = new Paragraph("Titulo de Ejemplo.\n", Negritas);
            parrafonegrito.Alignment = 1;
            doc.Add(parrafonegrito);

            PdfPTable tablitainvisible = new PdfPTable(1);
            addCell(tablitainvisible, "", 1);
            doc.Add(tablitainvisible);

            //Tabla colorada de cualquier color
            PdfPTable tablita = new PdfPTable(1);
            PdfPCell celdacolorada = new PdfPCell(new Phrase("Ejemplo de color"));
            BaseColor color = new BaseColor(1, 2, 6);
            celdacolorada.BackgroundColor = color;
            tablita.AddCell(celdacolorada);
            doc.Add(tablita);

            PdfPTable tablitainvisible1 = new PdfPTable(1);
            addCell(tablitainvisible1, "", 1);
            doc.Add(tablitainvisible1);

            //Se agregara texto con : y lo siguiente sera tener tablas con texto... Para esto
            //Para codigo
            Paragraph Codigo = new Paragraph("Codigo: ");
            Codigo.IndentationLeft = 60;
            Codigo.IndentationRight = 60;

            Chunk lineaCodigo = new Chunk("Resultado de Codigo");
            Codigo.Add(lineaCodigo);
            doc.Add(Codigo);

            //Para Descripcion
            Paragraph Descripcion = new Paragraph("Descripcion: ");
            Descripcion.IndentationLeft = 60;
            Descripcion.IndentationRight = 60;
            
            Chunk lineaDescripcion = new Chunk("Resultado de Descripcion");
            Descripcion.Add(lineaDescripcion);
            doc.Add(Descripcion);

            var fontchico = FontFactory.GetFont("Segoe UI", 9.5f, BaseColor.BLACK);
            Paragraph espaciolinea = new Paragraph("\n");
            espaciolinea.IndentationLeft = 60;
            espaciolinea.IndentationRight = 60;
            doc.Add(espaciolinea);

            //Se ocupa revisar el tamanio
            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 35f, 50f, 40f, 50f };
            table.SetWidths(widths);
            addCell(table, "    Marca:", 1);
            addCell(table, "Resultado de Marca", 1);
            addCell(table, "Equipo:", 1);
            addCell(table, "Resultado de Modelo", 1);
            doc.Add(table);

            PdfPTable espacio = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(espacio, "", 1);
            doc.Add(espacio);

            //Numero Serial y Numero de Modelo
            PdfPTable table1 = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table1.SetWidths(widths);
            addCell(table1, "Numero Serial:", 10);
            addCell(table1, "Resultado Serial", 1);
            addCell(table1, "Numero Modelo:", 1);
            addCell(table1, "Resultado Modelo", 1);
            doc.Add(table1);

            PdfPTable espacio1 = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(espacio1, "", 1);
            doc.Add(espacio1);

            //Numero de Bateria y Proveedor
            PdfPTable table2 = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table2.SetWidths(widths);
            addCell(table2, "No. de Bateria:", 10);
            addCell(table2, "Resultado Bateria", 1);
            addCell(table2, "Proveedor:", 1);
            addCell(table2, "Resultado Proveedor", 1);
            doc.Add(table2);

            PdfPTable espacio2 = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(espacio2, "", 1);
            doc.Add(espacio2);

            //Usuario y Departamento
            PdfPTable table3 = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table3.SetWidths(widths);
            addCell(table3, "Usuario:", 10);
            addCell(table3, "Resultado Usuario", 1);
            addCell(table3, "Departamento:", 1);
            addCell(table3, "Resultado Depto", 1);
            doc.Add(table3);

            PdfPTable espacio3 = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(espacio3, "", 1);
            doc.Add(espacio3);

            //Notas y Cuadro de Texto
            PdfPTable nota = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(nota, "Nota:", 1);
            doc.Add(nota);

            PdfPTable NotaTabla = new PdfPTable(1);
            NotaTabla.DefaultCell.FixedHeight = 40f;
            NotaTabla.AddCell("");
            doc.Add(NotaTabla);

            PdfPTable espacio4 = new PdfPTable(1);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(widths);
            addCell(espacio4, "", 1);
            doc.Add(espacio4);

            //Notas y Cuadro de Texto
            PdfPTable table4 = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table4.SetWidths(widths);
            addCell(table4, "Depto. de Sistemas:", 10);
            addCell(table4, "Depto Sistemas", 1);
            addCell(table4, "Gerente de Depto.:", 1);
            addCell(table4, "Gerente Depto", 1);
            doc.Add(table4);

            //Para agregar texto acerca de condiciones
            var font = FontFactory.GetFont("Segoe UI", 12.5f, BaseColor.BLACK);
            Paragraph condicionesparrafo = new Paragraph("CONDICIONES DE USO DE EQUIPO:\n", font);
            //condicionesparrafo.Alignment = Element.ALIGN_LEFT;
            //condicionesparrafo.IndentationRight = 30;
            condicionesparrafo.IndentationLeft = 60;
            condicionesparrafo.Font = font;
            doc.Add(condicionesparrafo);

            
            Paragraph condicionesparrafo1 = new Paragraph("1. Cuando Amphenol TCS de Mexico asigne un equipo de comunicacion, "
                + "el usuario estara en el entendido que es directamente responsable del correcto uso y cuidado del mismo\n", fontchico);
            condicionesparrafo1.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo1.IndentationLeft = 60;
            condicionesparrafo1.IndentationRight = 60;
            doc.Add(condicionesparrafo1);

            Paragraph condicionesparrafo2 = new Paragraph("2. En caso de perdida debera ser reportado al Departamento de Sistemas de Informacion (IT Departament)\n", fontchico);
            condicionesparrafo2.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo2.IndentationLeft = 60;
            condicionesparrafo2.IndentationRight = 60;
            doc.Add(condicionesparrafo2);

            Paragraph condicionesparrafo3 = new Paragraph("3. En caso de Daño, Robo, Perdida, imputable al usuario, queda el "
                + "obligado a repararlo, reemplazarlo por uno igual de la misma marca"
                + "y modelo, o bien a pagar en efectivo el costo comercial del equipo en el momento de percance\n", fontchico);
            condicionesparrafo3.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo3.IndentationLeft = 60;
            condicionesparrafo3.IndentationRight = 60;
            doc.Add(condicionesparrafo3);

            Paragraph condicionesparrafo4 = new Paragraph("4. El usuario debera confirmar que el equipo requerido se encuentre en buen estado y funcionando al recibirlo\n", fontchico);
            condicionesparrafo4.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo4.IndentationLeft = 60;
            condicionesparrafo4.IndentationRight = 60;
            doc.Add(condicionesparrafo4);

            Paragraph condicionesparrafo5 = new Paragraph("5. El usuario debera confirmar que el equipo requerido se encuentre en estado y funcionando al recibirlo\n", fontchico);
            condicionesparrafo5.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo5.IndentationLeft = 60;
            condicionesparrafo5.IndentationRight = 60;
            doc.Add(condicionesparrafo5);

            Paragraph condicionesparrafo6 = new Paragraph("6. En caso de Robo en vehiculo, el usuario tiene la responsabilidad " +
                "de reemplazar por uno igual o bien pagar en efectivo el costo comercial.\n" + "Acepto y firmo de conformidad como custodio del " +
                "equipo descrito en esta responsiva, y en caso de extravio o mal uso del mismo estoy de acuerdo para que se me descuente via nomina el costo del mismo:", fontchico);
            condicionesparrafo6.Alignment = Element.ALIGN_JUSTIFIED;
            condicionesparrafo6.IndentationLeft = 60;
            condicionesparrafo6.IndentationRight = 60;
            doc.Add(condicionesparrafo6);

            Paragraph espaciolinea1 = new Paragraph("\n");
            espaciolinea1.IndentationLeft = 60;
            espaciolinea1.IndentationRight = 60;
            doc.Add(espaciolinea1);

            //Para agregar un lineado debajo del texto
            Paragraph NomCompleto = new Paragraph("Nombre Completo: ");
            NomCompleto.IndentationLeft = 60;
            NomCompleto.IndentationRight = 60;

            Chunk linea = new Chunk("                                         ");
            linea.SetUnderline(1f, -3f);
            NomCompleto.Add(linea);

            Chunk firma = new Chunk(" Firma: ");
            //linea.SetUnderline(1f, -3f);
            NomCompleto.Add(firma);

            Chunk linea1 = new Chunk("                    ");
            linea1.SetUnderline(1f, -3f);
            NomCompleto.Add(linea1);
            
            Chunk fecha = new Chunk(" Fecha: ");
            //linea.SetUnderline(1f, -3f);
            NomCompleto.Add(fecha);

            Chunk linea2 = new Chunk("                        ");
            linea2.SetUnderline(1f, -3f);
            NomCompleto.Add(linea2);
            doc.Add(NomCompleto);

            Paragraph NoEmpleado = new Paragraph("Numero de Empleado: ");
            NoEmpleado.IndentationLeft = 60;
            NoEmpleado.IndentationRight = 60;

            Chunk linea3 = new Chunk("                                   ");
            linea3.SetUnderline(1f, -3f);
            NoEmpleado.Add(linea3);
            doc.Add(NoEmpleado);
            //Para conseguir valores de un cuadro de texto
            doc.Add(new Phrase(this.textBox1.Text.Trim()));
            
            //Se cierra el documento
            doc.Close();

            MessageBox.Show("Se ha creado un nuevo documento PDF!");
            
        }

        private static void addCell(PdfPTable table, string text, int rowspan)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 13, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, times));
            cell.Rowspan = rowspan;
            cell.FixedHeight = 18f;
            cell.Border = 0;
            cell.HorizontalAlignment = PdfPCell.LEFT_BORDER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
