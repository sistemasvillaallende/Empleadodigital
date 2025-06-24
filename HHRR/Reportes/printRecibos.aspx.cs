using HHRR;
using HHRR.Reportes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = iTextSharp.text.Image;

namespace HHRR.Reportes
{
    public partial class printRecibos : System.Web.UI.Page
    {
        Paragraph salto = new Paragraph()
        {
            SpacingAfter = 0f,
            SpacingBefore = 0f,
            PaddingTop = 0f
        };
        Font _standardFont = new Font(
            Font.FontFamily.HELVETICA, 7,
            Font.NORMAL, BaseColor.BLACK);
        Font _encabezado = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 12,
            Font.BOLD, BaseColor.BLACK);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["anio"] == null)
                    Response.Redirect("../index.aspx");
                if (Request.QueryString["cod_tipo_liq"] == null)
                    Response.Redirect("../index.aspx");
                if (Request.QueryString["nro_liq"] == null)
                    Response.Redirect("../index.aspx");

                ShowPdf(CreatePDF2());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ShowPdf(byte[] strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", $"attachment; filename=" +
                "Cedulon_" + Convert.ToInt32(Request.QueryString["NROCEDULON"]) + ".pdf");

            // Evita que el navegador cachee el archivo
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

        private PdfPTable getEncabezado(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(3)
                {
                    WidthPercentage = 100
                };

                tblEncabezado.SetWidths(new float[] { 30, 55, 15 });
                PdfPCell clIzquierda = new PdfPCell()
                {
                    BorderWidth = 1f,
                    PaddingLeft = 5,
                };

                Paragraph Linea1I = new Paragraph();
                Linea1I.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.BOLD));
                Linea1I.SpacingAfter = 0f;
                Linea1I.SpacingBefore = 0f;
                Linea1I.PaddingTop = 0f;
                Linea1I.SetLeading(8, 0);
                Linea1I.Add(new Chunk("MUNICIPALIDAD DE VILLA ALLENDE\n"));
                Linea1I.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea1I.Add(new Chunk("AV. GOYCOCHEA 586\n"));
                Linea1I.Add(new Chunk("LOCALIDAD: VILLA ALLENDE\n"));
                Linea1I.Add(new Chunk("NRO. INSCRIPCIÓN: A32"));
                clIzquierda.AddElement(Linea1I);


                tblEncabezado.AddCell(clIzquierda);

                PdfPCell clCentro = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                };

                Paragraph Linea1C = new Paragraph();
                Linea1C.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea1C.SpacingAfter = 0f;
                Linea1C.SpacingBefore = 0f;
                Linea1C.PaddingTop = 0f;
                Linea1C.SetLeading(8, 0);
                Linea1C.Alignment = Element.ALIGN_CENTER;
                Linea1C.Add(new Chunk("CUIT: 33-65057573-9\n"));
                Linea1C.Alignment = Element.ALIGN_RIGHT;
                Linea1C.Add(new Chunk(lstDetallle[0].NRO_ORDEN + "\n"));
                Linea1C.Add(new Chunk("\n"));
                Linea1C.Alignment = Element.ALIGN_CENTER;
                Linea1C.Add(new Chunk("CAJA DE JUBILACIONES PENS. Y RETIROS DE LA PROV. CORDOBA"));
                clCentro.AddElement(Linea1C);

                tblEncabezado.AddCell(clCentro);

                PdfPCell clDerecha = new PdfPCell()
                {
                    BorderWidth = 1f,
                    PaddingLeft = 5,
                };

                Paragraph Linea1D = new Paragraph();
                Linea1D.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.BOLD));
                Linea1D.SpacingAfter = 0f;
                Linea1D.SpacingBefore = 0f;
                Linea1D.PaddingTop = 0f;
                Linea1D.SetLeading(8, 0);
                Linea1D.Add(new Chunk("FECHA DE PAGO\n"));
                Linea1D.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea1D.Add(new Chunk(lstDetallle[0].FECHA_PAGO));
                clDerecha.AddElement(Linea1D);

                tblEncabezado.AddCell(clDerecha);

                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private PdfPTable getEncabezado2(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };

                tblEncabezado.SetWidths(new float[] { 10, 40, 15, 25, 10 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea11 = new Paragraph();
                Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea11.SpacingAfter = 0f;
                Linea11.SpacingBefore = 0f;
                Linea11.PaddingTop = 0f;
                Linea11.SetLeading(8, 0);
                Linea11.Add(new Chunk("LEGAJO\n"));
                Linea11.Add(new Chunk(lstDetallle[0].LEGAJO));
                cl1.AddElement(Linea11);
                tblEncabezado.AddCell(cl1);

                PdfPCell cl2 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea12 = new Paragraph();
                Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea12.SpacingAfter = 0f;
                Linea12.SpacingBefore = 0f;
                Linea12.PaddingTop = 0f;
                Linea12.SetLeading(8, 0);
                Linea12.Alignment = Element.ALIGN_CENTER;
                Linea12.Add("APELLIDO Y NOMBRE\n");
                Linea12.Add(new Chunk(lstDetallle[0].NOMBRE));
                cl2.AddElement(Linea12);
                tblEncabezado.AddCell(cl2);

                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Add("FECHA INGRESO\n");
                Linea13.Add(new Chunk(lstDetallle[0].FECHA_INGRESO));
                cl3.AddElement(Linea13);
                tblEncabezado.AddCell(cl3);

                PdfPCell cl4 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea14 = new Paragraph();
                Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea14.SpacingAfter = 0f;
                Linea14.SpacingBefore = 0f;
                Linea14.PaddingTop = 0f;
                Linea14.SetLeading(8, 0);
                Linea14.Add("TIPO   NRO. DOCUMENTO\n");
                Linea14.Add("DNI " + lstDetallle[0].NRO_DOC);
                cl4.AddElement(Linea14);
                tblEncabezado.AddCell(cl4);

                PdfPCell cl5 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea15 = new Paragraph();
                Linea15.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea15.SpacingAfter = 0f;
                Linea15.SpacingBefore = 0f;
                Linea15.PaddingTop = 0f;
                Linea15.SetLeading(8, 0);
                Linea15.Alignment = Element.ALIGN_CENTER;
                Linea15.Add("TIPO LIQ.\n");
                Linea15.Add(new Chunk(lstDetallle[0].TIPO_LIQ));
                cl5.AddElement(Linea15);
                tblEncabezado.AddCell(cl5);

                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PdfPTable getEncabezado3(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };

                tblEncabezado.SetWidths(new float[] { 10, 10, 45, 35 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea11 = new Paragraph();
                Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea11.SpacingAfter = 0f;
                Linea11.SpacingBefore = 0f;
                Linea11.PaddingTop = 0f;
                Linea11.SetLeading(8, 0);
                Linea11.Add(new Chunk("SECCION\n"));
                Linea11.Add(new Chunk(lstDetallle[0].SECCION));
                cl1.AddElement(Linea11);
                tblEncabezado.AddCell(cl1);

                PdfPCell cl2 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea12 = new Paragraph();
                Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea12.SpacingAfter = 0f;
                Linea12.SpacingBefore = 0f;
                Linea12.PaddingTop = 0f;
                Linea12.SetLeading(8, 0);
                Linea12.Alignment = Element.ALIGN_CENTER;
                Linea12.Add("CAT\n");
                Linea12.Add(new Chunk(lstDetallle[0].CATEGORIA));
                cl2.AddElement(Linea12);
                tblEncabezado.AddCell(cl2);

                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_CENTER;
                Linea13.Add("CARGO/TAREA\n");
                cl3.AddElement(Linea13);
                Paragraph Linea23 = new Paragraph();
                Linea23.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea23.SpacingAfter = 0f;
                Linea23.SpacingBefore = 0f;
                Linea23.PaddingTop = 0f;
                Linea23.SetLeading(8, 0);
                Linea23.Add(lstDetallle[0].TIPO_CONTRATACION + "\n");
                Linea23.Add(lstDetallle[0].CARGO);
                cl3.AddElement(Linea23);
                tblEncabezado.AddCell(cl3);

                PdfPCell cl4 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea14 = new Paragraph();
                Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea14.SpacingAfter = 0f;
                Linea14.SpacingBefore = 0f;
                Linea14.PaddingTop = 0f;
                Linea14.SetLeading(8, 0);
                Linea14.Add("PERIODO LIQUIDACION\n");
                Linea14.Add(lstDetallle[0].PERIODO_LIQUIDACION);
                cl4.AddElement(Linea14);
                tblEncabezado.AddCell(cl4);

                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private PdfPTable getEncabezado4(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(3)
                {
                    WidthPercentage = 100
                };

                tblEncabezado.SetWidths(new float[] { 60, 15, 25 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    PaddingLeft = 0,
                    PaddingBottom = 0,
                    PaddingTop = 0,
                    PaddingRight = 0,
                    Padding = 0,
                };
                PdfPTable tblTitulo = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                PdfPCell clTitulo = new PdfPCell()
                {
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    BorderWidthTop = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };
                Paragraph Linea11 = new Paragraph();
                Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea11.SpacingAfter = 0f;
                Linea11.SpacingBefore = 0f;
                Linea11.PaddingTop = 0f;
                Linea11.SetLeading(8, 0);
                Linea11.Alignment = Element.ALIGN_CENTER;
                Linea11.Add(new Chunk("ULTIMO DEPOSITO\n"));
                clTitulo.AddElement(Linea11);
                tblTitulo.AddCell(clTitulo);
                cl1.AddElement(tblTitulo);

                PdfPTable tblDetalle = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };

                tblDetalle.SetWidths(new float[] { 25, 75 });
                PdfPCell cl1Det = new PdfPCell()
                {
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 1f,
                    BorderWidthTop = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };
                Paragraph Linea1Det = new Paragraph();
                Linea1Det.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea1Det.SpacingAfter = 0f;
                Linea1Det.SpacingBefore = 0f;
                Linea1Det.PaddingTop = 0f;
                Linea1Det.SetLeading(8, 0);
                Linea1Det.Alignment = Element.ALIGN_CENTER;
                Linea1Det.Add(new Chunk("FECHA\n"));
                Linea1Det.Add(new Chunk(lstDetallle[0].FECHA_ULTIMO_PERIODO));
                cl1Det.AddElement(Linea1Det);
                tblDetalle.AddCell(cl1Det);

                PdfPCell cl2Det = new PdfPCell()
                {
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 1f,
                    BorderWidthTop = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };
                Paragraph Linea2Det = new Paragraph();
                Linea2Det.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea2Det.SpacingAfter = 0f;
                Linea2Det.SpacingBefore = 0f;
                Linea2Det.PaddingTop = 0f;
                Linea2Det.SetLeading(8, 0);
                Linea2Det.Alignment = Element.ALIGN_CENTER;
                Linea2Det.Add(new Chunk("PERIODO\n"));
                Linea2Det.Add(new Chunk(lstDetallle[0].PERIODO_ULTIMO));
                cl2Det.AddElement(Linea2Det);
                tblDetalle.AddCell(cl2Det);

                cl1.AddElement(tblDetalle);

                tblEncabezado.AddCell(cl1);

                PdfPCell cl2 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea12 = new Paragraph();
                Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea12.SpacingAfter = 0f;
                Linea12.SpacingBefore = 0f;
                Linea12.PaddingTop = 0f;
                Linea12.SetLeading(8, 0);
                Linea12.Alignment = Element.ALIGN_CENTER;
                Linea12.Add("CUIL/CUIT\n");
                Linea12.Add(new Chunk(lstDetallle[0].CUIT));
                cl2.AddElement(Linea12);
                tblEncabezado.AddCell(cl2);

                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidth = 1f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_CENTER;
                Linea13.Add("SUELDO O JORNAL BASICO\n");
                Linea13.Add(new Chunk(string.Format("{0:c}", lstDetallle[0].SUELTO_BASICO)));
                cl3.AddElement(Linea13);

                tblEncabezado.AddCell(cl3);


                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PdfPTable getDetalle(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(6)
                {
                    WidthPercentage = 100,
                };

                tblEncabezado.SetWidths(new float[] { 7, 32, 7, 18, 18, 18 });
                int i = 0;
                foreach (var item in lstDetallle)
                {
                    PdfPCell cl1 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea11 = new Paragraph();
                    Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea11.SpacingAfter = 0f;
                    Linea11.SpacingBefore = 0f;
                    Linea11.PaddingTop = 0f;
                    Linea11.SetLeading(8, 0);
                    Linea11.Add(new Chunk(item.cod_concepto_liq.ToString()));
                    cl1.AddElement(Linea11);
                    tblEncabezado.AddCell(cl1);

                    PdfPCell cl2 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea12 = new Paragraph();
                    Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea12.SpacingAfter = 0f;
                    Linea12.SpacingBefore = 0f;
                    Linea12.PaddingTop = 0f;
                    Linea12.SetLeading(8, 0);
                    Linea12.Add(new Chunk(item.desc_concepto_liq));
                    cl2.AddElement(Linea12);
                    tblEncabezado.AddCell(cl2);

                    PdfPCell cl3 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea13 = new Paragraph();
                    Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea13.SpacingAfter = 0f;
                    Linea13.SpacingBefore = 0f;
                    Linea13.PaddingTop = 0f;
                    Linea13.SetLeading(8, 0);
                    Linea13.Alignment = Element.ALIGN_RIGHT;
                    Linea13.Add(item.unidades.ToString());
                    cl3.AddElement(Linea13);
                    tblEncabezado.AddCell(cl3);

                    PdfPCell cl4 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea14 = new Paragraph();
                    Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea14.SpacingAfter = 0f;
                    Linea14.SpacingBefore = 0f;
                    Linea14.PaddingTop = 0f;
                    Linea14.SetLeading(8, 0);
                    Linea14.Alignment = Element.ALIGN_RIGHT;
                    Linea14.Add(string.Format("{0:c}", item.hab_con_descuento));
                    cl4.AddElement(Linea14);
                    tblEncabezado.AddCell(cl4);

                    PdfPCell cl5 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea15 = new Paragraph();
                    Linea15.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea15.SpacingAfter = 0f;
                    Linea15.SpacingBefore = 0f;
                    Linea15.PaddingTop = 0f;
                    Linea15.SetLeading(8, 0);
                    Linea15.Alignment = Element.ALIGN_RIGHT;
                    Linea15.Add(string.Format("{0:c}", item.hab_sin_descuento));
                    cl5.AddElement(Linea15);
                    tblEncabezado.AddCell(cl5);

                    PdfPCell cl6 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea16 = new Paragraph();
                    Linea16.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                    Linea16.SpacingAfter = 0f;
                    Linea16.SpacingBefore = 0f;
                    Linea16.PaddingTop = 0f;
                    Linea16.SetLeading(8, 0);
                    Linea16.Add(string.Format("{0:c}", item.descuentos));
                    Linea16.Alignment = Element.ALIGN_RIGHT;
                    cl6.AddElement(Linea16);
                    tblEncabezado.AddCell(cl6);
                    i++;
                }
                for (int j = i; j <= 22; j++)
                {
                    PdfPCell cl1 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea11 = new Paragraph();
                    Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea11.SpacingAfter = 0f;
                    Linea11.SpacingBefore = 0f;
                    Linea11.PaddingTop = 0f;
                    Linea11.SetLeading(8, 0);
                    Linea11.Add(new Chunk("."));
                    cl1.AddElement(Linea11);
                    tblEncabezado.AddCell(cl1);

                    PdfPCell cl2 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea12 = new Paragraph();
                    Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea12.SpacingAfter = 0f;
                    Linea12.SpacingBefore = 0f;
                    Linea12.PaddingTop = 0f;
                    Linea12.SetLeading(8, 0);
                    Linea12.Add(new Chunk("."));
                    cl2.AddElement(Linea12);
                    tblEncabezado.AddCell(cl2);

                    PdfPCell cl3 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea13 = new Paragraph();
                    Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea13.SpacingAfter = 0f;
                    Linea13.SpacingBefore = 0f;
                    Linea13.PaddingTop = 0f;
                    Linea13.SetLeading(8, 0);
                    Linea13.Alignment = Element.ALIGN_RIGHT;
                    Linea13.Add(".");
                    cl3.AddElement(Linea13);
                    tblEncabezado.AddCell(cl3);

                    PdfPCell cl4 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea14 = new Paragraph();
                    Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea14.SpacingAfter = 0f;
                    Linea14.SpacingBefore = 0f;
                    Linea14.PaddingTop = 0f;
                    Linea14.SetLeading(8, 0);
                    Linea14.Alignment = Element.ALIGN_RIGHT;
                    Linea14.Add(".");
                    cl4.AddElement(Linea14);
                    tblEncabezado.AddCell(cl4);

                    PdfPCell cl5 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 0f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea15 = new Paragraph();
                    Linea15.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea15.SpacingAfter = 0f;
                    Linea15.SpacingBefore = 0f;
                    Linea15.PaddingTop = 0f;
                    Linea15.SetLeading(8, 0);
                    Linea15.Alignment = Element.ALIGN_RIGHT;
                    Linea15.Add(".");
                    cl5.AddElement(Linea15);
                    tblEncabezado.AddCell(cl5);

                    PdfPCell cl6 = new PdfPCell()
                    {
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 5,
                        PaddingBottom = 0,
                    };

                    Paragraph Linea16 = new Paragraph();
                    Linea16.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL, BaseColor.WHITE));
                    Linea16.SpacingAfter = 0f;
                    Linea16.SpacingBefore = 0f;
                    Linea16.PaddingTop = 0f;
                    Linea16.SetLeading(8, 0);
                    Linea16.Add(".");
                    Linea16.Alignment = Element.ALIGN_RIGHT;
                    cl6.AddElement(Linea16);
                    tblEncabezado.AddCell(cl6);
                }
                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private PdfPTable getTotal(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(6)
                {
                    WidthPercentage = 100,
                };

                tblEncabezado.SetWidths(new float[] { 7, 32, 7, 18, 18, 18 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea11 = new Paragraph();
                Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea11.SpacingAfter = 0f;
                Linea11.SpacingBefore = 0f;
                Linea11.PaddingTop = 0f;
                Linea11.SetLeading(8, 0);
                Linea11.Add("");
                cl1.AddElement(Linea11);
                tblEncabezado.AddCell(cl1);

                PdfPCell cl2 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea12 = new Paragraph();
                Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea12.SpacingAfter = 0f;
                Linea12.SpacingBefore = 0f;
                Linea12.PaddingTop = 0f;
                Linea12.SetLeading(8, 0);
                Linea12.Add("");
                cl2.AddElement(Linea12);
                tblEncabezado.AddCell(cl2);

                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_RIGHT;
                Linea13.Add("");
                cl3.AddElement(Linea13);
                tblEncabezado.AddCell(cl3);

                PdfPCell cl4 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea14 = new Paragraph();
                Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea14.SpacingAfter = 0f;
                Linea14.SpacingBefore = 0f;
                Linea14.PaddingTop = 0f;
                Linea14.SetLeading(8, 0);
                Linea14.Alignment = Element.ALIGN_RIGHT;
                Linea14.Add(string.Format("{0:c}", lstDetallle[lstDetallle.Count() - 1].tot_hab_con_descuento));
                cl4.AddElement(Linea14);
                tblEncabezado.AddCell(cl4);

                PdfPCell cl5 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea15 = new Paragraph();
                Linea15.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea15.SpacingAfter = 0f;
                Linea15.SpacingBefore = 0f;
                Linea15.PaddingTop = 0f;
                Linea15.SetLeading(8, 0);
                Linea15.Alignment = Element.ALIGN_RIGHT;
                Linea15.Add(string.Format("{0:c}", lstDetallle[lstDetallle.Count() - 1].tot_hab_sin_descuento));
                cl5.AddElement(Linea15);
                tblEncabezado.AddCell(cl5);

                PdfPCell cl6 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea16 = new Paragraph();
                Linea16.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea16.SpacingAfter = 0f;
                Linea16.SpacingBefore = 0f;
                Linea16.PaddingTop = 0f;
                Linea16.SetLeading(8, 0);
                Linea16.Add(string.Format("{0:c}", lstDetallle[lstDetallle.Count() - 1].tot_descuento));
                Linea16.Alignment = Element.ALIGN_RIGHT;
                cl6.AddElement(Linea16);
                tblEncabezado.AddCell(cl6);


                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private PdfPTable getTotal2(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(4)
                {
                    WidthPercentage = 100,
                };

                tblEncabezado.SetWidths(new float[] { 46, 18, 18, 18 });


                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_RIGHT;
                Linea13.Add("");
                cl3.AddElement(Linea13);
                tblEncabezado.AddCell(cl3);

                PdfPCell cl4 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                };

                Paragraph Linea24 = new Paragraph();
                Linea24.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea24.SpacingAfter = 0f;
                Linea24.SpacingBefore = 0f;
                Linea24.PaddingTop = 0f;
                Linea24.SetLeading(8, 0);
                Linea24.Alignment = Element.ALIGN_CENTER;
                Linea24.Add("T.HAB. CON DCTO");
                cl4.AddElement(Linea24);
                tblEncabezado.AddCell(cl4);

                PdfPCell cl5 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                };

                Paragraph Linea25 = new Paragraph();
                Linea25.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea25.SpacingAfter = 0f;
                Linea25.SpacingBefore = 0f;
                Linea25.PaddingTop = 0f;
                Linea25.SetLeading(8, 0);
                Linea25.Alignment = Element.ALIGN_CENTER;
                Linea25.Add("T.HAB. SIN DCTO");
                cl5.AddElement(Linea25);
                tblEncabezado.AddCell(cl5);

                PdfPCell cl6 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                };

                Paragraph Linea26 = new Paragraph();
                Linea26.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea26.SpacingAfter = 0f;
                Linea26.SpacingBefore = 0f;
                Linea26.PaddingTop = 0f;
                Linea26.SetLeading(8, 0);
                Linea26.Alignment = Element.ALIGN_CENTER;
                Linea26.Add("TOT DESCUENTO");
                cl6.AddElement(Linea26);
                tblEncabezado.AddCell(cl6);


                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PdfPTable getTotal3(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(3)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 8f,
                };

                tblEncabezado.SetWidths(new float[] { 55, 22.5f, 22.5f });


                PdfPCell cl3 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,

                };

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_RIGHT;
                Linea13.Add("");
                cl3.AddElement(Linea13);
                tblEncabezado.AddCell(cl3);

                PdfPCell cl4 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea24 = new Paragraph();
                Linea24.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.BOLD));
                Linea24.SpacingAfter = 0f;
                Linea24.SpacingBefore = 0f;
                Linea24.PaddingTop = 0f;
                Linea24.SetLeading(8, 0);
                Linea24.Alignment = Element.ALIGN_LEFT;
                Linea24.Add("NETO A COBRAR:");
                cl4.AddElement(Linea24);
                tblEncabezado.AddCell(cl4);

                PdfPCell cl5 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 0f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea25 = new Paragraph();
                Linea25.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.BOLD));
                Linea25.SpacingAfter = 0f;
                Linea25.SpacingBefore = 0f;
                Linea25.PaddingTop = 0f;
                Linea25.SetLeading(8, 0);
                Linea25.Alignment = Element.ALIGN_RIGHT;
                Linea25.Add(string.Format("{0:c}",
                    lstDetallle[lstDetallle.Count() - 1].SUELDO_NETO));
                cl5.AddElement(Linea25);
                tblEncabezado.AddCell(cl5);

                PdfPCell cl6 = new PdfPCell()
                {
                    BorderWidthTop = 0f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };


                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private PdfPTable getTotal4(PdfWriter wri, List<sueldo_detalle> lstDetallle)
        {
            try
            {
                PdfPTable tblEncabezado = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 8f,
                };

                tblEncabezado.SetWidths(new float[] { 60, 40 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 0f,
                    PaddingLeft = 5,
                    PaddingBottom = 5,
                };

                Paragraph Linea11 = new Paragraph();
                Linea11.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea11.SpacingAfter = 15f;
                Linea11.SpacingBefore = 0f;
                Linea11.PaddingTop = 0f;
                Linea11.SetLeading(8, 0);
                Linea11.Alignment = Element.ALIGN_LEFT;
                Linea11.Add(string.Format("SON:    {0:C}", lstDetallle[lstDetallle.Count() - 1].SUELDO_EN_LETRAS));
                cl1.AddElement(Linea11);

                Paragraph Linea12 = new Paragraph();
                Linea12.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea12.SpacingAfter = 0f;
                Linea12.SpacingBefore = 0f;
                Linea12.PaddingTop = 0f;
                Linea12.SetLeading(8, 0);
                Linea12.Alignment = Element.ALIGN_CENTER;
                Linea12.Add("Ud. Se encuentra con cobertura de ASOCIART ART. AT. MEDICA 24hs.");
                cl1.AddElement(Linea12);

                Paragraph Linea14 = new Paragraph();
                Linea14.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea14.SpacingAfter = 35f;
                Linea14.SpacingBefore = 0f;
                Linea14.PaddingTop = 0f;
                Linea14.SetLeading(8, 0);
                Linea14.Alignment = Element.ALIGN_CENTER;
                Linea14.Add("0800-888-0093");
                cl1.AddElement(Linea14);

                Paragraph Linea13 = new Paragraph();
                Linea13.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea13.SpacingAfter = 0f;
                Linea13.SpacingBefore = 0f;
                Linea13.PaddingTop = 0f;
                Linea13.SetLeading(8, 0);
                Linea13.Alignment = Element.ALIGN_LEFT;
                Linea13.Add("PARA EL EMPLEADO");
                cl1.AddElement(Linea13);
                tblEncabezado.AddCell(cl1);

                Image png;

                png = Image.GetInstance(
                    "https://vecino.villaallende.gov.ar/App_Themes/images/firma_sec_gob.jpeg");
                png.ScaleAbsolute(125f, 85f);
                PdfPCell clLogo = new PdfPCell()
                {
                    BorderWidthRight = 1,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 0f,
                    PaddingTop = 5f,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                };
                png.Alignment = Element.ALIGN_CENTER;
                clLogo.AddElement(png);
                LineSeparator line = new LineSeparator(1f, 90f, BaseColor.BLACK, Element.ALIGN_CENTER, 1);
                clLogo.AddElement(line);
                Paragraph Linea21 = new Paragraph();
                Linea21.Font = new Font(FontFactory.GetFont("Calibri", 6, Font.NORMAL));
                Linea21.SpacingAfter = 5f;
                Linea21.SpacingBefore = 0f;
                Linea21.PaddingTop = 0f;
                Linea21.SetLeading(8, 0);
                Linea21.Alignment = Element.ALIGN_CENTER;
                Linea21.Add("FIRMA DEL EMPLEADOR");
                clLogo.AddElement(Linea21);
                tblEncabezado.AddCell(clLogo);
                return tblEncabezado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //    private PdfPTable getTitular(Cedulones objCedulon)
        //    {
        //        try
        //        {
        //            PdfPTable tblTitular = new PdfPTable(4)
        //            {
        //                SpacingBefore = 10,
        //                WidthPercentage = 100
        //            };
        //            tblTitular.SetWidths(new float[] { 10, 40, 25, 25 });
        //            Image pngTitular;

        //            pngTitular = Image.GetInstance(
        //                "https://vecino.villaallende.gov.ar/img/" + "usuario.png");

        //            PdfPCell clLogoTitular = new PdfPCell()
        //            {
        //                Image = pngTitular,
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                BorderWidthLeft = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10
        //            };

        //            tblTitular.AddCell(clLogoTitular);
        //            PdfPCell clProp = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10
        //            };
        //            Paragraph pT = new Paragraph();
        //            pT.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            pT.Add(objCedulon.nombre);
        //            clProp.AddElement(pT);


        //            clProp.AddElement(salto);
        //            if (objCedulon.CUIT.Length > 5)
        //            {
        //                clProp.AddElement(new Phrase(string.Format("CUIT: {0}-{1}-{2}",
        //                    objCedulon.CUIT.Substring(0, 2),
        //                    objCedulon.CUIT.Substring(2, 8),
        //                    objCedulon.CUIT.Substring(10, 1)), _standardFont));
        //            }
        //            else
        //                clProp.AddElement(new Phrase(
        //                    objCedulon.CUIT, _standardFont));
        //            tblTitular.AddCell(clProp);

        //            PdfPCell clVenc = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10
        //            };


        //            clVenc.AddElement(new Phrase("VENCIMIENTO:", _standardFont));
        //            clVenc.AddElement(salto);
        //            clVenc.AddElement(new Phrase("TOTAL A PAGAR: ", _standardFont));
        //            tblTitular.AddCell(clVenc);

        //            PdfPCell clVenc2 = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                BorderWidthRight = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                HorizontalAlignment = Element.ALIGN_RIGHT
        //            };
        //            clVenc2.AddElement(new Phrase(string.Format("{0:d}",
        //                objCedulon.vencimiento), _standardFont));
        //            clVenc2.AddElement(salto);
        //            clVenc2.AddElement(new Phrase(string.Format("{0:c}",
        //                objCedulon.montoPagar), _standardFont));
        //            tblTitular.AddCell(clVenc2);
        //            return tblTitular;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    private PdfPTable getPieIzquierda(Cedulones objCedulon)
        //    {
        //        try
        //        {
        //            PdfPTable tblTitular = new PdfPTable(4)
        //            {
        //                WidthPercentage = 100
        //            };
        //            tblTitular.SetWidths(new float[] { 25, 25, 25, 25 });

        //            PdfPCell clPropI = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthLeft = 1f,
        //                Padding = 10
        //            };
        //            clPropI.AddElement(new Phrase(objCedulon.nombre, _standardFont));
        //            clPropI.AddElement(salto);

        //            if (objCedulon.CUIT.Length > 5)
        //            {
        //                clPropI.AddElement(new Phrase(string.Format("CUIT: {0}-{1}-{2}",
        //                    objCedulon.CUIT.Substring(0, 2),
        //                    objCedulon.CUIT.Substring(2, 8),
        //                    objCedulon.CUIT.Substring(10, 1)), _standardFont));
        //            }
        //            else
        //                clPropI.AddElement(new Phrase(
        //                    objCedulon.CUIT, _standardFont));


        //            clPropI.AddElement(salto);
        //            clPropI.AddElement(new Phrase(string.Format("Vencimiento: {0}",
        //                objCedulon.vencimiento.ToShortDateString()), _standardFont));
        //            tblTitular.AddCell(clPropI);

        //            PdfPCell clBienI = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                PaddingBottom = 10,
        //                Padding = 10
        //            };
        //            clBienI.AddElement(new Phrase(string.Format("Dominio: {0}",
        //                objCedulon.denominacion), _standardFont));
        //            clBienI.AddElement(salto);
        //            clBienI.AddElement(new Phrase(objCedulon.detalle, _standardFont));
        //            clBienI.AddElement(salto);
        //            clBienI.AddElement(new Phrase(string.Format("Monto: {0:c}",
        //                objCedulon.montoPagar), _standardFont));

        //            tblTitular.AddCell(clBienI);


        //            PdfPCell clPropD = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthLeft = 1f,
        //                PaddingBottom = 10,
        //                Padding = 10
        //            };
        //            clPropD.AddElement(new Phrase(objCedulon.nombre, _standardFont));
        //            clPropD.AddElement(salto);

        //            if (objCedulon.CUIT.Length > 5)
        //            {
        //                clPropD.AddElement(new Phrase(string.Format("CUIT: {0}-{1}-{2}",
        //                    objCedulon.CUIT.Substring(0, 2),
        //                    objCedulon.CUIT.Substring(2, 8),
        //                    objCedulon.CUIT.Substring(10, 1)), _standardFont));
        //            }
        //            else
        //                clPropD.AddElement(new Phrase(
        //                    objCedulon.CUIT, _standardFont));

        //            clPropD.AddElement(salto);
        //            clPropD.AddElement(new Phrase(string.Format("Vencimiento: {0}",
        //                objCedulon.vencimiento.ToShortDateString()), _standardFont));
        //            clPropD.AddElement(salto);
        //            clPropD.AddElement(new Phrase(string.Format("Nro. Comprobante: {0}",
        //                objCedulon.nroCedulon), _standardFont));
        //            tblTitular.AddCell(clPropD);

        //            PdfPCell clBienD = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthRight = 1f,
        //                PaddingBottom = 10,
        //                Padding = 10
        //            };
        //            clBienD.AddElement(new Phrase(string.Format("Dominio: {0}",
        //                objCedulon.denominacion), _standardFont));
        //            clBienD.AddElement(salto);
        //            clBienD.AddElement(new Phrase(objCedulon.detalle, _standardFont));
        //            clBienD.AddElement(salto);
        //            clBienD.AddElement(new Phrase(string.Format("Monto: {0:c}",
        //                objCedulon.montoPagar), _standardFont));

        //            tblTitular.AddCell(clBienD);

        //            return tblTitular;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    private PdfPTable getPie2(PdfWriter wri, Cedulones objCedulon)
        //    {
        //        try
        //        {
        //            PdfPTable tblEncabezado = new PdfPTable(2)
        //            {
        //                WidthPercentage = 100
        //            };

        //            tblEncabezado.SetWidths(new float[] { 50, 50 });
        //            PdfPCell clLogo = new PdfPCell(new Phrase())
        //            {
        //                BorderWidth = 0,
        //                BorderWidthBottom = 1f,
        //                BorderWidthLeft = 1f,
        //                BorderWidthRight = 1f,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            };

        //            PdfPCell clDatos = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthBottom = 1f,
        //                BorderWidthLeft = 1f,
        //                PaddingLeft = 50,
        //                PaddingRight = 50
        //            };


        //            clDatos.AddElement(salto);
        //            PdfContentByte cb = wri.DirectContent;
        //            Barcode39 code25 = new Barcode39();
        //            code25.GenerateChecksum = false;

        //            string nro = "C0" + objCedulon.nroCedulon.ToString().Trim();

        //            code25.Code = nro;

        //            Phrase rapi = new Phrase();

        //            clDatos.AddElement(code25.CreateImageWithBarcode(cb, null, null));


        //            tblEncabezado.AddCell(clDatos);
        //            tblEncabezado.AddCell(clLogo);
        //            return tblEncabezado;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    private PdfPTable getBien(PdfWriter wri, Cedulones objCedulon)
        //    {
        //        try
        //        {
        //            PdfPTable tblBien = new PdfPTable(2)
        //            {
        //                SpacingBefore = 10,
        //                WidthPercentage = 100
        //            };
        //            tblBien.SetWidths(new float[] { 10, 90 });
        //            Image pngBien;

        //            pngBien = Image.GetInstance(
        //                "https://vecino.villaallende.gov.ar/App_Themes/images/" + "Auto.png");

        //            PdfPCell clLogoBien = new PdfPCell()
        //            {
        //                Image = pngBien,
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                BorderWidthLeft = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            };

        //            tblBien.AddCell(clLogoBien);

        //            PdfPCell clBien = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            };

        //            Paragraph pT = new Paragraph();
        //            pT.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            pT.Add(objCedulon.denominacion);
        //            clBien.AddElement(pT);

        //            clBien.AddElement(salto);
        //            clBien.AddElement(new Phrase(objCedulon.detalle, _standardFont));
        //            tblBien.AddCell(clBien);

        //            return tblBien;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    private PdfPTable getNota()
        //    {
        //        try
        //        {
        //            StringBuilder str = new StringBuilder();
        //            string msjDecreto = ConfigurationManager.AppSettings["mensajeDecreto"].ToString();
        //            str.AppendFormat("{0}", msjDecreto);
        //            string mensaje = string.Empty;
        //            if (Request.QueryString["ANUAL"] != null)
        //                mensaje =
        //                    "DE HABER OPTADO POR EL PAGO ANUAL ,EN CASO DE CAMBIO DE RADICACION O BAJA , NO CORRESPONDERA  REINTEGRO.";
        //            else
        //                mensaje = str.ToString();

        //            PdfPTable tblNota = new PdfPTable(1)
        //            {
        //                SpacingBefore = 10,
        //                WidthPercentage = 100
        //            };
        //            PdfPCell clNota = new PdfPCell()
        //            {
        //                BorderWidth = 1f,
        //                PaddingBottom = 20,
        //                PaddingTop = 20,
        //                HorizontalAlignment = Element.ALIGN_CENTER,
        //                VerticalAlignment = Element.ALIGN_MIDDLE,
        //                BackgroundColor = Color.LIGHT_GRAY
        //            };
        //            Paragraph p = new Paragraph();
        //            p.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            p.Alignment = Element.ALIGN_CENTER;
        //            p.Add(mensaje);
        //            clNota.AddElement(p);
        //            tblNota.AddCell(clNota);
        //            return tblNota;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    private PdfPTable getDetalleTitulo()
        //    {
        //        try
        //        {
        //            PdfPTable tblDetTitulo = new PdfPTable(1)
        //            {
        //                SpacingBefore = 10,
        //                SpacingAfter = 10,
        //                WidthPercentage = 100
        //            };
        //            PdfPCell clDetTitulo = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                HorizontalAlignment = Element.ALIGN_CENTER,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            };
        //            Paragraph pT = new Paragraph();
        //            pT.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            pT.Alignment = Element.ALIGN_CENTER;
        //            pT.Add("DETALLE DEUDA");
        //            clDetTitulo.AddElement(pT);
        //            tblDetTitulo.AddCell(clDetTitulo);
        //            return tblDetTitulo;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    private PdfPTable getDetalle(Cedulones objCedulon, ref int lineas)
        //    {
        //        try
        //        {
        //            PdfPTable tblDetalle = new PdfPTable(7)
        //            {
        //                WidthPercentage = 100,

        //            };
        //            tblDetalle.SetWidths(new float[] { 10, 25, 15, 10, 10, 10, 10 });
        //            PdfPCell clPeriodo = new PdfPCell(new Paragraph("Periodo", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                BorderWidthLeft = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };
        //            PdfPCell clConcepto = new PdfPCell(new Paragraph("Concepto", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10
        //            };
        //            PdfPCell clMontoOriginal = new PdfPCell(new Paragraph("Monto Original", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };
        //            PdfPCell clInteres = new PdfPCell(
        //                new Paragraph("Interes", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };

        //            PdfPCell clCredito = new PdfPCell(new Paragraph("Crédito", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };

        //            PdfPCell clDescuento = new PdfPCell(new Paragraph("Descuento", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };

        //            PdfPCell clTotal = new PdfPCell(new Paragraph("Total", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                BorderWidthBottom = 1f,
        //                BorderWidthRight = 1f,
        //                PaddingBottom = 10,
        //                PaddingTop = 10,
        //                PaddingLeft = 5
        //            };

        //            tblDetalle.AddCell(clPeriodo);
        //            tblDetalle.AddCell(clConcepto);
        //            tblDetalle.AddCell(clMontoOriginal);
        //            tblDetalle.AddCell(clInteres);
        //            tblDetalle.AddCell(clCredito);
        //            tblDetalle.AddCell(clDescuento);
        //            tblDetalle.AddCell(clTotal);
        //            List<DetalleCedulon> lst = new List<DetalleCedulon>();

        //            if (Request.QueryString["ANUAL"] == null)
        //            {
        //                lst = DetalleCedulon.readAuto(objCedulon.nroCedulon);
        //            }
        //            else
        //            {
        //                lst = DetalleCedulon.readAutoAnual(objCedulon.nroCedulon);
        //                if (objCedulon.montoPagar != lst.Sum(d => d.montoPagado))
        //                {
        //                    DetalleCedulon objDetalle = new DetalleCedulon();
        //                    objDetalle.periodo = "2022/00";
        //                    objDetalle.concepto = "REDONDEO";
        //                    objDetalle.montoPagado = objCedulon.montoPagar - lst.Sum(d => d.montoPagado);
        //                    lst.Add(objDetalle);
        //                }
        //            }

        //            lineas = lst.Count;
        //            foreach (var item in lst)
        //            {
        //                PdfPCell clPeriodoD = new PdfPCell(new Paragraph(item.periodo.ToString(),
        //                    _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };
        //                PdfPCell clConceptod = new PdfPCell(new Paragraph(item.concepto,
        //                    _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };
        //                PdfPCell clMontoOriginald = null;
        //                if (Request.QueryString["ANUAL"] == null)
        //                {
        //                    clMontoOriginald = new PdfPCell(new Paragraph(
        //                        string.Format("{0:c}", item.montoOriginal), _standardFont))
        //                    {
        //                        BorderWidth = 0
        //                    };
        //                }
        //                else
        //                {
        //                    clMontoOriginald = new PdfPCell(new Paragraph(
        //                        string.Format("{0:c}", item.montoPagado), _standardFont))
        //                    {
        //                        BorderWidth = 0
        //                    };
        //                }
        //                PdfPCell clInteresesD = new PdfPCell(
        //                    new Paragraph(string.Format("{0:c}", item.recargo), _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };
        //                PdfPCell clCreditoD = new PdfPCell(new Paragraph(string.Format("{0:c}",
        //                    item.saldoFavor), _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };

        //                PdfPCell clDescuentoD = new PdfPCell(new Paragraph(string.Format("{0:c}",
        //item.descInteres), _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };

        //                PdfPCell clTotalD = new PdfPCell(new Paragraph(string.Format("{0:c}",
        //item.montoPagado), _standardFont))
        //                {
        //                    BorderWidth = 0
        //                };

        //                tblDetalle.AddCell(clPeriodoD);
        //                tblDetalle.AddCell(clConceptod);
        //                tblDetalle.AddCell(clMontoOriginald);
        //                tblDetalle.AddCell(clInteresesD);
        //                tblDetalle.AddCell(clCreditoD);
        //                tblDetalle.AddCell(clDescuentoD);
        //                tblDetalle.AddCell(clTotalD);
        //            }

        //            PdfPCell clPeriodoT = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0,
        //                PaddingLeft = 5
        //            };
        //            Paragraph ppT = new Paragraph();
        //            ppT.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            ppT.Add("TOTAL");
        //            clPeriodoT.AddElement(ppT);
        //            PdfPCell clConceptoT = new PdfPCell(new Paragraph(" ", _standardFont))
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0
        //            };

        //            PdfPCell clMontoOriginalT = null;
        //            if (Request.QueryString["ANUAL"] == null)
        //            {
        //                clMontoOriginalT = new PdfPCell(new Paragraph(
        //                    string.Format("{0:c}", lst.Sum(l => l.montoOriginal)), _standardFont))
        //                {
        //                    BorderWidth = 0,
        //                    BorderWidthTop = 1f,
        //                    PaddingLeft = 5,
        //                    PaddingBottom = 0,
        //                    PaddingTop = 0
        //                };
        //                Paragraph pmoT = new Paragraph();
        //                pmoT.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //                pmoT.Add(string.Format("{0:c}", lst.Sum(l => l.montoOriginal)));
        //                clMontoOriginalT.AddElement(pmoT);
        //            }
        //            else
        //            {
        //                clMontoOriginalT = new PdfPCell()
        //                {
        //                    BorderWidth = 0,
        //                    BorderWidthTop = 1f,
        //                    PaddingLeft = 5,
        //                    PaddingBottom = 0,
        //                    PaddingTop = 0
        //                };
        //                Paragraph pmoT2 = new Paragraph();
        //                pmoT2.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //                pmoT2.Add(string.Format("{0:c}", lst.Sum(l => l.montoPagado)));
        //                clMontoOriginalT.AddElement(pmoT2);
        //            }
        //            PdfPCell clInteresT = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0,
        //                PaddingLeft = 5
        //            };
        //            Paragraph prt = new Paragraph();
        //            prt.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            prt.Add(string.Format("{0:c}", lst.Sum(l => l.recargo)));
        //            clInteresT.AddElement(prt);

        //            PdfPCell clCreditoT = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0,
        //                PaddingLeft = 5
        //            };
        //            Paragraph pct = new Paragraph();
        //            pct.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            pct.Add(string.Format("{0:c}", lst.Sum(l => l.saldoFavor)));
        //            clCreditoT.AddElement(pct);


        //            PdfPCell clDescuentoT = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0,
        //                PaddingLeft = 5
        //            };
        //            Paragraph pdt = new Paragraph();
        //            pdt.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            pdt.Add(string.Format("{0:c}", lst.Sum(l => l.descInteres)));
        //            clDescuentoT.AddElement(pdt);


        //            PdfPCell clTotalT = new PdfPCell()
        //            {
        //                BorderWidth = 0,
        //                BorderWidthTop = 1f,
        //                PaddingBottom = 0,
        //                PaddingTop = 0,
        //                PaddingLeft = 5
        //            };
        //            Paragraph ptt = new Paragraph();
        //            ptt.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
        //            ptt.Add(string.Format("{0:c}", lst.Sum(l => l.montoPagado)));
        //            clTotalT.AddElement(ptt);


        //            tblDetalle.AddCell(clPeriodoT);
        //            tblDetalle.AddCell(clConceptoT);
        //            tblDetalle.AddCell(clMontoOriginalT);
        //            tblDetalle.AddCell(clInteresT);
        //            tblDetalle.AddCell(clCreditoT);
        //            tblDetalle.AddCell(clDescuentoT);
        //            tblDetalle.AddCell(clTotalT);

        //            return tblDetalle;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }


        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.A4, 20, 20, 30, 20);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);
            List<Entities.AUX_MAESTRO_SUELDO> lst = BLL.AUX_MAESTRO_SUELDO.read(legajo, legajo,
                Convert.ToInt32(Request.QueryString["anio"]),
                Convert.ToInt32(Request.QueryString["cod_tipo_liq"]), Convert.ToInt32(Request.QueryString["nro_liq"]));


            List<sueldo_detalle> lstDetallle = new List<sueldo_detalle>();
            sueldo_detalle objDetalle;


            foreach (var item in lst)
            {
                decimal tot_hab_con_descuento = 0;
                decimal tot_sin_con_descuento = 0;
                decimal tot_descuento = 0;
                foreach (var item2 in item.lstDetalle)
                {
                    objDetalle = new sueldo_detalle();
                    objDetalle.NRO_ORDEN = item.nro_orden.ToString();
                    objDetalle.FECHA_PAGO = item.fecha_pago.ToShortDateString();
                    objDetalle.LEGAJO = item.legajo.ToString();
                    objDetalle.CATEGORIA = item.cod_categoria.ToString();
                    objDetalle.NOMBRE = item.nombre;
                    objDetalle.FECHA_INGRESO = item.fecha_ingreso.ToShortDateString();
                    objDetalle.TIPO_DOC = item.des_tipo_documento;
                    objDetalle.NRO_DOC = item.nro_documento;
                    objDetalle.TIPO_LIQ = item.cod_tipo_liq.ToString();
                    objDetalle.TIPO_CONTRATACION = item.clasificacion_personal;
                    objDetalle.CARGO = item.tarea;
                    objDetalle.SECCION = item.cod_seccion.ToString();
                    objDetalle.PERIODO_LIQUIDACION = item.des_liquidacion.Trim();
                    objDetalle.FECHA_ULTIMO_PERIODO = item.fecha_liquidacion.ToShortDateString();
                    objDetalle.PERIODO_ULTIMO = item.per_ult_dep.Trim();
                    objDetalle.CUIT = item.cuil;
                    objDetalle.SUELTO_BASICO = item.sueldo_basico;
                    objDetalle.SUELDO_NETO = item.importe_total;
                    objDetalle.cod_concepto_liq = item2.cod_concepto_liq;
                    if (item2.suma)
                        if (item2.sujeto_a_desc)
                        {
                            objDetalle.hab_con_descuento = item2.importe;
                            tot_hab_con_descuento += item2.importe;
                        }
                        else
                        {
                            objDetalle.hab_sin_descuento = item2.importe;
                            tot_sin_con_descuento += item2.importe;
                        }
                    else
                    {
                        objDetalle.descuentos = item2.importe;
                        tot_descuento += item2.importe;
                    }
                    objDetalle.tot_descuento = tot_descuento;
                    objDetalle.tot_hab_con_descuento = tot_hab_con_descuento;
                    objDetalle.tot_hab_sin_descuento = tot_sin_con_descuento;
                    objDetalle.desc_concepto_liq = item2.des_concepto_liq;
                    objDetalle.unidades = item2.unidades;
                    objDetalle.Coberturamedica = ConfigurationManager.AppSettings["coberturamedica"].ToString();
                    objDetalle.SUELDO_EN_LETRAS = conversiones.enletras(item.importe_total.ToString());
                    lstDetallle.Add(objDetalle);
                }
            }


            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();

                PdfPTable tblEncabezado = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };

                tblEncabezado.SetWidths(new float[] { 50, 50 });

                PdfPCell cl1 = new PdfPCell()
                {
                    BorderWidth = 0f
                };
                cl1.AddElement(getEncabezado(wri, lstDetallle));
                cl1.AddElement(getEncabezado2(wri, lstDetallle));
                cl1.AddElement(getEncabezado3(wri, lstDetallle));
                cl1.AddElement(getEncabezado4(wri, lstDetallle));
                cl1.AddElement(getDetalle(wri, lstDetallle));
                cl1.AddElement(getTotal(wri, lstDetallle));
                cl1.AddElement(getTotal2(wri, lstDetallle));
                cl1.AddElement(getTotal3(wri, lstDetallle));
                cl1.AddElement(getTotal4(wri, lstDetallle));

                tblEncabezado.AddCell(cl1);

                PdfPCell cl2 = new PdfPCell()
                {
                    BorderWidth = 0f
                };
                cl2.AddElement(getEncabezado(wri, lstDetallle));
                cl2.AddElement(getEncabezado2(wri, lstDetallle));
                cl2.AddElement(getEncabezado3(wri, lstDetallle));
                cl2.AddElement(getEncabezado4(wri, lstDetallle));
                cl2.AddElement(getDetalle(wri, lstDetallle));
                cl2.AddElement(getTotal(wri, lstDetallle));
                cl2.AddElement(getTotal2(wri, lstDetallle));
                cl2.AddElement(getTotal3(wri, lstDetallle));
                cl2.AddElement(getTotal4(wri, lstDetallle));

                tblEncabezado.AddCell(cl2);

                doc.Add(tblEncabezado);

                doc.Close();
                return output.ToArray();
            }
        }
    }
}