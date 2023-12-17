using Domain.Models;
using Infrastructure.Data;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;

        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ModelExistsAsync(int id)
        {
            return await _context.Models.AnyAsync(e => e.id == id);
        }

        public async Task<Model> GetModelAsync(int id)
        {
            return await _context.Models.FirstOrDefaultAsync(m => m.id == id);
        }

        public async Task AddModelAsync(Model model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateModelAsync(Model model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Model>> GetAllModelsAsync()
        {
            return await _context.Models.ToListAsync();
        }

        public async Task<bool> EntitySetIsNullAsync()
        {
            return _context.Models == null;
        }
        public async Task<string> GeneratePdfFileAsync(Model model)
        {
            string folderPath = "wwwroot/pdfs/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"DataSet_{model.id}.pdf";
            string filepath = System.IO.Path.Combine(folderPath, fileName);

            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                PageSize pageSize = PageSize.A4;
                Document document = new Document(pdfDocument, pageSize);

                // Add title
                Paragraph title = new Paragraph(model.Title)
                    .SetFontSize(24)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);

                // Add subtitle
                Paragraph subtitle = new Paragraph(model.SubTitle)
                    .SetFontSize(18)
                    .SetItalic()
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(subtitle);

                // Add description
                Paragraph description = new Paragraph(model.Description)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.JUSTIFIED);
                document.Add(description);

                // Add repository URL
                Paragraph repositoryURL = new Paragraph("Repository URL: " + model.RepositoryURL)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT);
                document.Add(repositoryURL);

                // Add licenses
                Paragraph licenses = new Paragraph("Licenses: " + model.Licenses)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT);
                document.Add(licenses);

                // Add accuracy
                Paragraph accuracy = new Paragraph("Accuracy: " + model.Accuracy.ToString())
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
