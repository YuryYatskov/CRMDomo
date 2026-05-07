namespace WebServer.API.Data.Extensions;

public static partial class InitialData
{
    public static IEnumerable<Counterparty> Counterparties =>
    [
        new Counterparty()
        {
            Id = new Guid("11dff400-b6bb-41aa-a851-e342b0a88480"),
            Name = "Kyiv Trade Group",
            FullName = "TOV \"Kyiv Trade Group\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40125678",
            Tin = "3012456789",
            Description = "Wholesale and retail trade of consumer goods across Ukraine.",

        },
        new Counterparty()
        {
            Id = new Guid("8383ff59-eaed-4b41-b3a3-f1225e04ecb3"),
            Name = "Dnipro Logistics Service",
            FullName = "TOV \"Dnipro Logistics Service\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "38901234",
            Tin = "2987654321",
            Description = "Freight transportation and warehouse logistics solutions.",

        },
        new Counterparty()
        {
            Id = new Guid("d45b5c6e-124d-4672-902b-d93d9fe8c7c0"),
            Name = "Lviv IT Solutions",
            FullName = "TOV \"Lviv IT Solutions\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41239876",
            Tin = "3123456789",
            Description = "Custom software development and IT consulting for SMEs.",

        },
        new Counterparty()
        {
            Id = new Guid("d3622d18-0e95-4179-8615-d0193d7bef0f"),
            Name = "Black Sea Export",
            FullName = "TOV \"Black Sea Export\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "37894561",
            Tin = "2876543210",
            Description = "Export of agricultural products to EU and Middle East markets.",

        },
        new Counterparty()
        {
            Id = new Guid("67625b1d-2227-4d12-94f3-4c9051edd337"),
            Name = "Green Energy Systems",
            FullName = "TOV \"Green Energy Systems\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "42356789",
            Tin = "3256789012",
            Description = "Design and installation of solar power plants and energy systems.",

        },
        new Counterparty()
        {
            Id = new Guid("ad31f8ce-fb4d-43e3-be13-5a065b50bcb8"),
            Name = "UkrBuild Invest",
            FullName = "TOV \"UkrBuild Invest\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39674521",
            Tin = "2901234567",
            Description = "Construction and investment projects in residential real estate.",

        },
        new Counterparty()
        {
            Id = new Guid("f3271cfe-a774-45d1-bbdc-7514c721ad9e"),
            Name = "Smart Retail Technologies",
            FullName = "TOV \"Smart Retail Technologies\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40567812",
            Tin = "3334567890",
            Description = "Development of POS and e‑commerce solutions for retail chains.",

        },
        new Counterparty()
        {
            Id = new Guid("c2022202-b471-42c9-9a47-7cd7767415db"),
            Name = "Carpathian Tourism Group",
            FullName = "TOV \"Carpathian Tourism Group\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "38765432",
            Tin = "2765432190",
            Description = "Organization of tours and hospitality services in the Carpathian region.",

        },
        new Counterparty()
        {
            Id = new Guid("b9338e49-0e0a-495c-85f8-0a5f0b89cdb9"),
            Name = "AgroInvest Holding",
            FullName = "TOV \"AgroInvest Holding\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41890234",
            Tin = "3198765401",
            Description = "Large-scale crop production and grain trading.",

        },
        new Counterparty()
        {
            Id = new Guid("e36fbf02-85ce-4172-a70e-c5605cb18bf9"),
            Name = "Metro Finance Consulting",
            FullName = "TOV \"Metro Finance Consulting\"",
            Supplier = false,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40213456",
            Tin = "3045678912",
            Description = "Financial advisory, audit, and tax consulting services.",

        },
        new Counterparty()
        {
            Id = new Guid("c5b02a6c-4ea6-4545-b4d0-96b372388a44"),
            Name = "Digital Media Studio",
            FullName = "TOV \"Digital Media Studio\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39123487",
            Tin = "2956781234",
            Description = "Production of digital content, advertising, and branding campaigns.",

        },
        new Counterparty()
        {
            Id = new Guid("d32ce8e5-74a9-49bc-8a9c-6c390193a60f"),
            Name = "Kyiv Medical Center Plus",
            FullName = "TOV \"Kyiv Medical Center Plus\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40987654",
            Tin = "3078912345",
            Description = "Private multidisciplinary medical clinic network.",

        },
        new Counterparty()
        {
            Id = new Guid("04a748aa-d494-4a11-9e30-11b84857755c"),
            Name = "Nova Transport Lines",
            FullName = "TOV \"Nova Transport Lines\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "38456721",
            Tin = "2812345679",
            Description = "Intercity and international passenger transportation services.",

        },
        new Counterparty()
        {
            Id = new Guid("0509c222-b676-4369-9e64-78b91f755d36"),
            Name = "EcoPack Ukraine",
            FullName = "TOV \"EcoPack Ukraine\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41457892",
            Tin = "3167890123",
            Description = "Manufacturing of eco‑friendly packaging materials.",

        },
            new Counterparty()
        {
            Id = new Guid("176c78c3-a66c-45fc-b056-43a66489bb9e"),
            Name = "City Food Production",
            FullName = "TOV \"City Food Production\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39901245",
            Tin = "2923456780",
            Description = "Production of packaged food and semi‑finished products.",

        },
        new Counterparty()
        {
            Id = new Guid("816d3652-6f7d-4802-a285-3d0bd94fa4e6"),
            Name = "IT Academy Pro",
            FullName = "TOV \"IT Academy Pro\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "42134567",
            Tin = "3234567801",
            Description = "Professional IT training and corporate education programs.",

        },
        new Counterparty()
        {
            Id = new Guid("e6b73249-9bdd-45ff-b5f1-e81ac06ee048"),
            Name = "Dnipro Steel Trade",
            FullName = "TOV \"Dnipro Steel Trade\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "38234590",
            Tin = "2790123456",
            Description = "Distribution of metal products and industrial materials.",

        },
        new Counterparty()
        {
            Id = new Guid("118eec7d-452c-4503-9dd7-af18949cc2c9"),
            Name = "Urban Development Group",
            FullName = "TOV \"Urban Development Group\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40765432",
            Tin = "3098765123",
            Description = "Urban planning, architecture, and construction management.",

        },
        new Counterparty()
        {
            Id = new Guid("d50e0213-94ad-4156-b650-676204a8fffa"),
            Name = "Fresh Market Logistics",
            FullName = "TOV \"Fresh Market Logistics\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39345678",
            Tin = "2967812345",
            Description = "Cold chain logistics for food and pharmaceuticals.",

        },
        new Counterparty()
        {
            Id = new Guid("6cf25954-b082-4b74-b832-7ef63b1f8257"),
            Name = "SkyNet Telecom",
            FullName = "TOV \"SkyNet Telecom\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41678903",
            Tin = "3189012345",
            Description = "Internet and telecommunication services for businesses and households.",

        },

        new Counterparty()
        {
            Id = new Guid("11117934-ddb6-4c55-bf67-344873056fe4"),
            Name = "Black Sea Shipping Agency",
            FullName = "TOV \"Black Sea Shipping Agency\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "38890123",
            Tin = "2834590123",
            Description = "Port agency and ship handling services in Black Sea ports.",

        },
        new Counterparty()
        {
            Id = new Guid("27224670-7176-4f13-b846-1d62b1f31fa7"),
            Name = "Lviv Coffee Roasters",
            FullName = "TOV \"Lviv Coffee Roasters\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41023456",
            Tin = "3056789345",
            Description = "Production and distribution of specialty coffee",

        },
        new Counterparty()
        {
            Id = new Guid("6d3bf032-60fb-4ab2-8f2b-55c93ecae25e"),
            Name = "Smart Home Engineering",
            FullName = "TOV \"Smart Home Engineering\"",
            Supplier = true,
            Seller = false,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39567841",
            Tin = "2945012367",
            Description = "Design and installation of smart home and building automation systems.",

        },
        new Counterparty()
        {
            Id = new Guid("64f96539-418e-44ac-8812-a00f3a2c3109"),
            Name = "IT Cloud Services",
            FullName = "TOV \"IT Cloud Services\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "41256780",
            Tin = "3134598760",
            Description = "Cloud infrastructure, hosting, and managed IT services.",

        },
        new Counterparty()
        {
            Id = new Guid("c4b4132a-b540-4509-9ba9-7335962e9ec7"),
            Name = "Dnipro Auto Trade",
            FullName = "TOV \"Dnipro Auto Trade\"",
            Supplier = false,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "39780123",
            Tin = "2934567810",
            Description = "Sale of new and used vehicles and related services.",

        },
        new Counterparty()
        {
            Id = new Guid("0e15ed50-0c5a-4810-b948-ff35ede011b9"),
            Name = "Kyiv Fashion Group",
            FullName = "TOV \"Kyiv Fashion Group\"",
            Supplier = true,
            Seller = true,
            FormOfOwnership = FormOfOwnership.LegalEntity,
            Edrpou = "40456781",
            Tin = "3023456791",
            Description = "Design, production, and retail of clothing and accessories.",
        },
    ];
}
