using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CvGenerator;

public class CvDocument : IDocument
{
    private readonly CvModel _model;

    public CvDocument(CvModel model)
    {
        _model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(40);
            page.Size(PageSizes.A4);
            page.DefaultTextStyle(x => x.FontSize(11));

            page.Content().Column(col =>
            {
                col.Spacing(10);

                // HEADER
                col.Item().Row(row =>
                {
                    // LEWA CZESC: imię + stanowisko + opis
                    row.RelativeItem().Column(left =>
                    {
                        left.Item().Text(_model.FullName)
                            .FontSize(24).Bold();
                        left.Item().PaddingVertical(3).Text(_model.Title)
                            .FontSize(14).FontColor(Colors.Grey.Darken2);
                        left.Item().PaddingTop(5).Text(_model.Summary);
                    });

                    // PRAWA CZESC: zdjęcie
                    row.ConstantItem(120).Element(PhotoBox);
                });

                // Szara kreska
                col.Item().PaddingVertical(10)
                    .LineHorizontal(1)
                    .LineColor(Colors.Grey.Lighten2);

                // BODY - dwie kolumny
                // BODY - dwie kolumny
                col.Item().Row(row =>
                {
                    // LEWA KOLUMNA: Experience
                    row.RelativeItem().PaddingRight(10).Column(left =>
                    {
                        left.Item().Text("Experience").Bold().FontSize(14);

                        foreach (var exp in _model.Experiences)
                        {
                            left.Item().PaddingVertical(5).Column(e =>
                            {
                                e.Item().Text($"{exp.Role} – {exp.Company}").FontSize(11).Bold();
                                e.Item().PaddingTop(5).PaddingBottom(5).Text(exp.Period)
                                    .FontSize(11)
                                    .FontColor(Colors.Grey.Darken3);
                                e.Item().PaddingTop(2).Text(exp.Description);

                                // Szara linia oddzielająca każde doświadczenie
                                e.Item().PaddingTop(5)
                                    .LineHorizontal(1)
                                    .LineColor(Colors.Grey.Lighten2);
                            });
                        }

                        // EDUCATION
                        left.Item().PaddingTop(10).Text("Education").Bold().FontSize(14);
                        foreach (var edu in _model.Education)
                        {
                            left.Item().PaddingVertical(5).Column(e =>
                            {
                                e.Item().Text(edu.School).FontSize(11).Bold();
                                e.Item().PaddingVertical(3).Text(edu.Degree).FontSize(11)
                                    .FontColor(Colors.Grey.Darken3);
                                e.Item().PaddingBottom(5).Text(edu.Period)
                                    .FontSize(10)
                                    .FontColor(Colors.Grey.Darken1);
                                if (!string.IsNullOrEmpty(edu.Description))
                                    e.Item().PaddingTop(2).Text(edu.Description);

                                e.Item().LineHorizontal(1)
                                    .LineColor(Colors.Grey.Lighten2);
                            });
                        }

                        // CERTIFICATES
                        left.Item().PaddingTop(10).Text("Certificates").Bold().FontSize(14);
                        foreach (var cert in _model.Certificates)
                        {
                            left.Item().PaddingVertical(5).Column(c =>
                            {
                                c.Item().Text(cert.Name).Bold();
                                c.Item().PaddingVertical(5).Text("Issued by: " + cert.Issuer + $" | {cert.Date}")
                                    .FontSize(11)
                                    .FontColor(Colors.Grey.Darken3);
                                c.Item().Text($"Identifier: {cert.Identifier}").FontSize(11)
                                    .FontColor(Colors.Grey.Darken3);
                            });
                        }
                    });

                    // Dodajemy pionową linię oddzielającą
                    row.ConstantItem(1).Background(Colors.Grey.Lighten2);

                    // PRAWA KOLUMNA: Skills + Languages
                    row.ConstantItem(180).PaddingLeft(10).Column(right =>
                    {
                        right.Spacing(10);

                        // Contact
                        right.Item().Text("Contact").Bold().FontSize(14);
                        right.Item().Column(contact =>
                        {
                            contact.Item().Padding(3).Text("Email").Bold();
                            contact.Item().Padding(3).Text(_model.Email)
                                .FontSize(11)
                                .FontColor(Colors.Grey.Darken3);
                            contact.Item().Padding(3).Text("Phone").Bold();
                            contact.Item().Padding(3).Text(_model.Phone)
                                .FontSize(11)
                                .FontColor(Colors.Grey.Darken3);
                            contact.Item().Padding(3).Text("Github").Bold();
                            contact.Item().Padding(3).Text(_model.GitHub)
                                .FontSize(11)
                                .FontColor(Colors.Grey.Darken3);
                        });

                        // Skills
                        right.Item().Text("Skills").Bold().FontSize(14);
                        right.Item().Column(colSkills =>
                        {
                            foreach (var skill in _model.Skills)
                            {
                                colSkills.Item()
                                    .Padding(3)
                                    .Text(skill);
                            }
                        });

                        // Languages
                        right.Item().PaddingTop(10).Text("Languages").Bold().FontSize(14);
                        right.Item().Column(colLang =>
                        {
                            foreach (var lang in _model.Languages)
                            {
                                colLang.Item()
                                    .Padding(3)
                                    .Text(lang);
                            }
                        });
                    });
                });

            });
        });
    }

    void PhotoBox(IContainer container)
    {
        container
            .Height(120)
            .Width(120)
            .Padding(5)
            .Image("logo/sample.png", ImageScaling.FitArea);
    }
}