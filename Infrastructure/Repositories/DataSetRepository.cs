using Domain.Models;
using Infrastructure.Data;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Infrastructure.Repositories
{
    public class DataSetRepository : IDataSetRepository
    {
        private readonly ApplicationDbContext _context;

        public DataSetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DataSetExistsAsync(int id)
        {
            return await _context.DataSets.AnyAsync(e => e.id == id);
        }

        public async Task<DataSet> GetDataSetAsync(int id)
        {
            return await _context.DataSets.FirstOrDefaultAsync(m => m.id == id);
        }

        public async Task AddDataSetAsync(DataSet dataSet)
        {
            _context.Add(dataSet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDataSetAsync(DataSet dataSet)
        {
            _context.Update(dataSet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDataSetAsync(int id)
        {
            var dataSet = await _context.DataSets.FindAsync(id);
            if (dataSet != null)
            {
                _context.DataSets.Remove(dataSet);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await _context.DataSets.ToListAsync();
        }

        public async Task<bool> EntitySetIsNullAsync()
        {
            return _context.DataSets == null;
        }
        public async Task<string> GeneratePdfFileAsync(DataSet dataSet)
        {
            string folderPath = "wwwroot/pdfs/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"DataSet_{dataSet.id}.pdf";
            string filepath = System.IO.Path.Combine(folderPath, fileName);

            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                PageSize pageSize = PageSize.A4;
                Document document = new Document(pdfDocument, pageSize);

                // Add title
                Paragraph title = new Paragraph(dataSet.Title)
                    .SetFontSize(24)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);

                // Add subtitle
                Paragraph subtitle = new Paragraph(dataSet.SubTitle)
                    .SetFontSize(18)
                    .SetItalic()
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(subtitle);

                // Add description
                Paragraph description = new Paragraph(dataSet.Description)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.JUSTIFIED);
                document.Add(description);

                // Add repository URL
                Paragraph repositoryURL = new Paragraph("Repository URL: " + dataSet.RepositoryURL)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT);
                document.Add(repositoryURL);

                // Add licenses
                Paragraph licenses = new Paragraph("Licenses: " + dataSet.Licenses)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT);
                document.Add(licenses);

                // Add accuracy
                Paragraph accuracy = new Paragraph("Accuracy: " + dataSet.Accuracy.ToString())
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT);
                document.Add(accuracy);

                // Close the document
                document.Close();
            }

            return filepath;
        }
    }
}
