namespace CvGenerator;

public class CvModel
{
    public string FullName { get; set; } = "";
    public string Title { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string GitHub { get; set; } = "";
    public string Location { get; set; } = "";
    public string Summary { get; set; } = "";

    public List<Experience> Experiences { get; set; } = new();
    public List<Education> Education { get; set; } = new();
    public List<Certificate> Certificates { get; set; } = new();
    public List<string> Skills { get; set; } = new();
    public List<string> Languages { get; set; } = new();
}

public class Experience
{
    public string Company { get; set; } = "";
    public string Role { get; set; } = "";
    public string Period { get; set; } = "";
    public string Description { get; set; } = "";
}

public class Education
{
    public string School { get; set; } = "";
    public string Degree { get; set; } = "";
    public string Period { get; set; } = "";
    public string Description { get; set; } = "";
}

public class Certificate
{
    public string Name { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Date { get; set; } = "";
    public string Identifier { get; set; } = "";
}