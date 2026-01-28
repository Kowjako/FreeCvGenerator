using CvGenerator;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var model = new CvModel
{
    FullName = "Monika Ostrowska",
    Title = "Senior .NET Software Engineer",
    Email = "monikaostrowska@email.com",
    Phone = "+48 123 123 123",
    Location = "Wroclaw, Poland",
    Summary = "I am a Software Engineer with 6+ years of commercial experience, with a passion for programming since my school years. I specialize in designing and developing microservices solutions. I thrive on challenges and my independent work has honed my precision, patience, and ability to accept feedback. I have strong skills in logical thinking, planning, and delivering reliable, maintainable software.",

    Skills = new List<string> { ".NET / C#", "ASP.NET (SignalR, WebAPI, Identity)", "Entity Framework / ADO.NET / Dapper", "MS SQL / MongoDB / PostgreSQL", "REST API / GraphQL / gRPC", "xUnit / NUnit / Moq", "RabbitMQ", "Docker, Powershell, CI/CD", "WPF / Windows Forms", "Azure & Terraform", "Angular, RxJs, TypeScript", "HTML, SCSS, Bootstrap", "Quartz.NET / Hangfire", "CQRS, DDD, Onion Architecture" },
    Languages = new List<string> { "Polish - Native", "English - Fluent" },

    Experiences = new List<Experience>
    {
        new Experience
        {
            Company = "Aegis Cloud Systems",
            Role = "Senior .NET / Angular Software Engineer",
            Period = "08.2022 – Present",
            Description = "Designed and delivered cloud-native, multi-tenant platforms used in large-scale enterprise environments. Took ownership of performance-critical services handling millions of requests daily, introduced observability and resilience patterns, and drove the adoption of Azure-native services to improve scalability, fault tolerance, and deployment automation."
        },
        
        new Experience
        {
            Company = "Finwave Technologies",
            Role = "Mid-level .NET Software Engineer",
            Period = "07.2020 – 07.2022",
            Description = "Built and evolved backend services for financial and billing systems supporting medium and large businesses. Modernized legacy architectures by migrating monolithic services to RESTful APIs and gRPC, optimized SQL queries for high-throughput workloads, and actively contributed to architectural decisions improving long-term maintainability."
        },
        
        new Experience
        {
            Company = "BluePeak Software",
            Role = "Junior .NET Software Engineer",
            Period = "06.2019 – 06.2020",
            Description = "Worked on enterprise-grade business applications, implementing new features and maintaining existing modules in ERP-like systems. Assisted in integrating external government and regulatory APIs, improved application stability through bug fixes and refactoring, and gained hands-on experience with large, production-scale codebases."
        },
    },
    Education = new List<Education>
    {
        new Education
        {
            School = "Wroclaw University of Science and Technology",
            Degree = "Computer Science, Bachelor",
            Period = "09.2017 - 12.2020"
        }
    },
    Certificates = new List<Certificate>
    {
        new Certificate
        {
            Name = "AZ-204 Azure Developer Associate",
            Issuer = "Microsoft",
            Date = "24.12.2025",
            Identifier = Guid.NewGuid().ToString()
        }
    }
};

var document = new CvDocument(model);
document.GeneratePdfAndShow();