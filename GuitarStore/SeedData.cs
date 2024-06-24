using GuitarStore.Contexts;
using GuitarStore.Models.Product;

namespace GuitarStore;

public class SeedData
{
    private static bool Ran;

    public static void SeedStores(AppDbContext context)
    {
        if (Ran) return;
        Ran = true;

        List<Store> stores =
        [
            new Store
            {
                Name = "EuroGuitar",
                Address = new Address { Street = "12 Rue de la Guitare", City = "Paris", PostalCode = "75001" },
                Image =
                    "https://media.gettyimages.com/id/1414428789/photo/group-of-classic-musical-guitar-instruments-on-display-in-a-music-shop-classical-vintage.jpg?s=612x612&w=0&k=20&c=OTsIy9p679S5SFNRUT6Gmk8Ec5gg7MYqZt6cBkzOLDo="
            },
            new Store
            {
                Name = "Strummers Music Shop",
                Address = new Address { Street = "34 Abbey Road", City = "Liverpool", PostalCode = "L1 3BX" },
                Image =
                    "https://media.gettyimages.com/id/78057641/photo/guitars-in-music-store.jpg?s=612x612&w=0&k=20&c=kPQaoZ5d9Wown6J_vLQjlKiaJLEbdDJeYRnqkeqUI0Y="
            },
            new Store
            {
                Name = "Guitar Heaven",
                Address = new Address { Street = "Hauptstraße 45", City = "Berlin", PostalCode = "10115" },
                Image =
                    "https://media.gettyimages.com/id/467222465/photo/choices-choices.jpg?s=612x612&w=0&k=20&c=CCKrQHtPtWvcC4BcLC4j6wYXj-GF42topd3ELWRTP-M="
            },
            new Store
            {
                Name = "Acoustic Waves",
                Address = new Address { Street = "Via della Musica 23", City = "Rome", PostalCode = "00100" },
                Image =
                    "https://media.gettyimages.com/id/1366021639/photo/row-of-classic-guitars-for-sale.jpg?s=612x612&w=0&k=20&c=rJq9SswpCRRuaClo-_wBwNvDkj_WfKv_-4MX0h6K8yI="
            },
            new Store
            {
                Name = "Fretboard Fantasia",
                Address = new Address { Street = "Calle de las Cuerdas 67", City = "Madrid", PostalCode = "28001" },
                Image =
                    "https://media.gettyimages.com/id/477154041/photo/guitars.jpg?s=612x612&w=0&k=20&c=IFKPoH0jmUNwDhWDNuDfmcxVnp6qoJ7hFlRvtd9Wais="
            },
            new Store
            {
                Name = "Jam Session Guitars",
                Address = new Address { Street = "Rua das Cordas 89", City = "Lisbon", PostalCode = "1000-001" },
                Image =
                    "https://media.gettyimages.com/id/1461645238/photo/traditional-moroccan-musical-instruments-for-sale-in-medina.jpg?s=612x612&w=0&k=20&c=0PTEyfC7RewNsfn_xFSQ52BtVwe2YiTXBhJn0INR0Rk="
            },
            new Store
            {
                Name = "Riff City Music",
                Address = new Address { Street = "Strøget 78", City = "Copenhagen", PostalCode = "1000" },
                Image =
                    "https://media.gettyimages.com/id/107191980/photo/different-classic-guitars-in-a-shop.jpg?s=612x612&w=0&k=20&c=fYlmwy3qf35zezS-ES7XpyCbqBXPnZ4cxHnUSaiZrXc="
            },
            new Store
            {
                Name = "Melody Masters",
                Address = new Address { Street = "Ul. Gitary 56", City = "Warsaw", PostalCode = "00-001" },
                Image =
                    "https://media.gettyimages.com/id/186459162/photo/collection-of-guitars.jpg?s=612x612&w=0&k=20&c=q3huMC3RbZACLndZsn4w7dIwD-Hxdifof0kCi7TxgCo="
            },
            new Store
            {
                Name = "Harmony House",
                Address =
                    new Address { Street = "Strada Chitarelor 34", City = "Bucharest", PostalCode = "010101" },
                Image =
                    "https://media.gettyimages.com/id/993400398/photo/lots-of-guitars.jpg?s=612x612&w=0&k=20&c=jDFHvl4Z1EcvZM0pGvveddfkMRdjwkAYiP9r-Zvbm6Q="
            },
            new Store
            {
                Name = "Tune Town Guitars",
                Address = new Address { Street = "Am Bach 12", City = "Vienna", PostalCode = "1010" },
                Image =
                    "https://media.gettyimages.com/id/80489013/photo/guitars.jpg?s=612x612&w=0&k=20&c=_E72SiGsKAX_2PkR-hzBLucZ6ac8TcX1rdF4gHABCuQ="
            }
        ];

        List<SellableProduct> products =
        [
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/851518598/photo/a-vintage-1965-fender-stratocaster-with-a-candy-apple-red-finish-electric-guitar-taken-on-june.jpg?s=612x612&w=0&k=20&c=v8LKXADJyD8PpQ3jAk9LXUrTHomA4dQNl7_ZjYJVxK0="
                ],
                Name = "Fender Stratocaster", GuitarType = GuitarEnum.ELECTRIC, Price = 1200,
                Description =
                    "The Fender Stratocaster is an iconic solid-body electric guitar known for its versatile tone and smooth playability. It features three single-coil pickups that deliver a wide range of tones, from bright and twangy to warm and mellow. The Stratocaster's comfortable contoured body, double-cutaway design, and synchronized tremolo bridge have made it a favorite among guitarists in almost every genre, from rock and blues to country and pop."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1942048694/photo/london-england-a-solid-body-gibson-les-paul-standard-gold-top-electric-guitar-signed-by.jpg?s=612x612&w=0&k=20&c=WB61y6GbJ0tsfYQWl_-6PEJVvbOrUS1MDSDhFx8iXgU="
                ],
                Name = "Gibson Les Paul Standard", GuitarType = GuitarEnum.ELECTRIC, Price = 2200,
                Description =
                    "The Gibson Les Paul Standard is a classic electric guitar renowned for its rich, powerful sound and luxurious finishes. With its mahogany body, maple top, and dual humbucking pickups, the Les Paul delivers thick, sustaining tones perfect for everything from bluesy licks to heavy rock riffs. Its iconic design, including a solid body and set neck construction, ensures exceptional sustain and resonance, making it a staple in the music industry for decades."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/455920986/photo/a-prs-se-floyd-custom-24-electric-guitar-with-a-sapphire-finish-taken-on-february-6-2014.jpg?s=612x612&w=0&k=20&c=4TdBPHNFi3x3lWLnOFLVs4eEUVjJYXCjtHgRudGAB7M="
                ],
                Name = "PRS Custom 24", GuitarType = GuitarEnum.ELECTRIC, Price = 2800,
                Description =
                    "The PRS Custom 24 is a high-end electric guitar celebrated for its modern yet versatile sound and impeccable craftsmanship. It features a carved figured maple top, mahogany back, and PRS's proprietary humbucking pickups, offering a balance of clarity, warmth, and sustain. The Custom 24's sleek body contours and ergonomic design make it comfortable to play for extended periods, while its 24-fret neck and patented tremolo bridge system cater to advanced players seeking precision and expressiveness."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/143511563/photo/an-epiphone-slash-signature-les-paul-standard-plus-top-electric-guitar-during-a-studio-shoot.jpg?s=612x612&w=0&k=20&c=e9Gkg-bQCTuqfDEjV2uS1ACZCLsQdWGU51IHSyIYzR4="
                ],
                Name = "Epiphone Les Paul Standard", GuitarType = GuitarEnum.ELECTRIC, Price = 600,
                Description =
                    "The Epiphone Les Paul Standard is an affordable rendition of the iconic Gibson Les Paul, known for its solid build quality and great tone. Featuring a mahogany body with a maple top, the Les Paul Standard delivers warm, fat tones through its humbucking pickups. It's a favorite among entry-level and intermediate players looking to capture the classic Les Paul sound without breaking the bank, making it a versatile option for various musical styles."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/153900919/photo/fender-road-worn-72-telecaster-deluxe-and-custom-electric-guitars-during-a-studio-shoot-for.jpg?s=612x612&w=0&k=20&c=fLReMDgjq_OeVVYpa0-sckLRlaXDxOgOqAzGbTQa3wk="
                ],
                Name = "Squier Classic Vibe Telecaster", GuitarType = GuitarEnum.ELECTRIC, Price = 450,
                Description =
                    "The Squier Classic Vibe Telecaster is a budget-friendly version of the legendary Fender Telecaster, known for its vintage-style tones and solid construction. With its alder body, maple neck, and single-coil pickups, the Classic Vibe Telecaster delivers clear, bright tones that are ideal for country, rock, and blues. Its classic design and affordability make it a popular choice for beginners and seasoned players alike who appreciate the Telecaster's timeless sound and style."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/143120955/photo/a-yamaha-pacifica-112v-electric-guitar-with-a-sonic-blue-finish-taken-on-october-5-2007.jpg?s=612x612&w=0&k=20&c=vez1XxidIW2IbJUIXAkek4wTu0FeUP8a6DdwqrM8mI8="
                ],
                Name = "Yamaha Pacifica 112V", GuitarType = GuitarEnum.ELECTRIC, Price = 300,
                Description =
                    "The Yamaha Pacifica 112V is a versatile electric guitar designed for beginner to intermediate players seeking quality and value. Featuring a solid alder body, maple neck, and Yamaha's own Alnico V pickups, the Pacifica 112V offers a balanced tone suitable for various musical genres. Its smooth playability, lightweight construction, and ergonomic design make it a comfortable choice for long practice sessions and live performances, making it one of Yamaha's most popular electric guitars."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1039914364/photo/an-ibanez-rg550-electric-guitar-with-desert-sun-yellow-finish-taken-on-february-7-2018.jpg?s=612x612&w=0&k=20&c=l-yoHLcT2hyv0fuzDfLfKNurExFYnI1HMpLtDy5ESMs="
                ],
                Name = "Ibanez RG550", GuitarType = GuitarEnum.ELECTRIC, Price = 1000,
                Description =
                    "The Ibanez RG550 is a high-performance electric guitar renowned for its fast-playing neck and aggressive tone, making it a favorite among shredders and metal guitarists. With its lightweight basswood body, maple neck, and Ibanez Edge tremolo bridge, the RG550 delivers excellent sustain and precise tuning stability. Equipped with humbucking pickups and versatile tone controls, the RG550 is capable of producing the sharp, articulate tones required for intricate solos and heavy riffs, making it a go-to instrument for players who demand speed and precision."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/494569951/photo/portrait-of-a-jackson-pro-series-dka8-dinky-electric-guitar-photographed-on-a-red-background.jpg?s=612x612&w=0&k=20&c=-2oFsv06fEgj18xQNmmxxeC6pQVsPDf-GZRbFsGfHLg="
                ],
                Name = "Jackson Dinky", GuitarType = GuitarEnum.ELECTRIC, Price = 800,
                Description =
                    "The Jackson Dinky is a sleek and fast-playing electric guitar designed for metal and rock musicians who prioritize speed and performance. Featuring a lightweight poplar body, bolt-on maple neck, and compound radius fingerboard, the Dinky offers effortless playability and exceptional upper fret access. Its high-output humbucking pickups deliver powerful, aggressive tones perfect for heavy rhythms and blistering solos. The Jackson Dinky's ergonomic design and iconic shark fin inlays make it a standout choice for players seeking a combination of style and substance on stage and in the studio."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/657268792/photo/a-gretsch-g5420t-electromatic-hollow-body-electric-guitar-taken-on-june-29-2016.jpg?s=612x612&w=0&k=20&c=iHqm3l9LS17epvQGxEs8Z9uP2z491df4db2rrfd2m5E="
                ],
                Name = "Gretsch G5420T Electromatic", GuitarType = GuitarEnum.ELECTRIC, Price = 850,
                Description =
                    "The Gretsch G5420T Electromatic is a classic hollow-body electric guitar known for its distinctive, warm tone and vintage-style aesthetics. Featuring a laminated maple body, maple neck, and Black Top Filter'Tron pickups, the G5420T delivers rich, resonant tones with a touch of twang and clarity. Its Bigsby licensed B60 vibrato tailpiece adds smooth pitch modulation, enhancing its versatility for jazz, blues, rockabilly, and more. The Gretsch G5420T's elegant design and authentic Gretsch sound make it a beloved choice among players looking to capture the timeless essence of hollow-body guitars."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/102167421/photo/studio-still-life-of-a-1958-gibson-explorer-guitar-photographed-in-the-united-kingdom.jpg?s=612x612&w=0&k=20&c=Tw1bmBh0qUz9Hc88TLkJhXSMsY7yBtB1r91HiJqsbP4="
                ],
                Name = "Gibson Explorer", GuitarType = GuitarEnum.ELECTRIC, Price = 2000,
                Description =
                    "The Gibson Explorer is a futuristic electric guitar known for its bold design, powerful sound, and solid construction. With its mahogany body and set neck, the Explorer delivers thick, aggressive tones that are perfect for hard rock and metal. Its dual humbucking pickups offer high output and sustain, while its distinctive angular body shape provides a comfortable playing experience whether standing or sitting. The Gibson Explorer's unique appearance and commanding presence on stage have made it a favorite among guitarists seeking a blend of style and performance."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1244449687/photo/an-epiphone-1961-les-paul-sg-standard-electric-guitar-with-an-aged-cherry-finish-taken-on.jpg?s=612x612&w=0&k=20&c=Y2ETRnLl7OfrJk1jkHjv0FhGHyOAtvytA_KFCKObyVM="
                ],
                Name = "Epiphone SG G-400", GuitarType = GuitarEnum.ELECTRIC, Price = 400,
                Description =
                    "The Epiphone SG G-400 is an affordable version of the iconic Gibson SG electric guitar, prized for its lightweight body and raw, gritty sound. Featuring a mahogany body and set neck, the SG G-400 delivers punchy, aggressive tones through its dual humbucking pickups. Its slim-taper neck profile and smooth fretboard facilitate fast, comfortable playing, making it a favorite among rock and blues guitarists. The Epiphone SG G-400's classic design and budget-friendly price tag make it an excellent choice for players seeking a straightforward, no-nonsense guitar with legendary heritage."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/150704751/photo/a-prs-se-custom-24-electric-guitar-in-a-whale-blue-finish-taken-on-may-20-2009.jpg?s=612x612&w=0&k=20&c=2nZ6BXJs6c4fYb2i9EMD6Bjr-30kDacDw73rjeDG9hY="
                ],
                Name = "PRS SE Custom 24", GuitarType = GuitarEnum.ELECTRIC, Price = 800,
                Description =
                    "The PRS SE Custom 24 is an affordable version of PRS's flagship Custom 24 model, offering exceptional tone and playability at a more accessible price point. Featuring a maple top with mahogany back, a Wide Thin maple neck, and PRS-designed humbucking pickups, the SE Custom 24 delivers a versatile range of tones from sparkling cleans to thick overdriven leads. Its sleek body contours, ergonomic design, and PRS patented tremolo bridge ensure precise tuning stability and comfortable playability, making it a preferred choice for guitarists across various genres."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/469569534/photo/a-taylor-150e-and-taylor-214ce-k-dlx-electro-acoustic-guitar-taken-on-july-17-2014.jpg?s=612x612&w=0&k=20&c=oogRMuUX5AvY2aAz57j3zCr2GeEohdFQnTjmy_gCz-8="
                ],
                Name = "Taylor 214ce", GuitarType = GuitarEnum.ACOUSTIC, Price = 1200,
                Description =
                    "The Taylor 214ce is a high-quality acoustic-electric guitar known for its balanced sound and comfortable playability. Featuring a solid Sitka spruce top and layered rosewood back and sides, the 214ce delivers clear, articulate tones with excellent projection and sustain. Equipped with Taylor's Expression System 2 electronics, this guitar ensures natural sound reproduction when amplified, making it ideal for live performances and recording. The Taylor 214ce's versatile sound, sleek design, and Taylor's renowned craftsmanship make it a popular choice among discerning acoustic guitarists."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/991319406/photo/a-2017-martin-d-28-dreadnought-acoustic-guitar-taken-on-november-7-2017.jpg?s=612x612&w=0&k=20&c=rAWec_a8Ys57p0cWP6_zicJ-ASKefNvOd1DOVqcohDI="
                ],
                Name = "Martin D-28", GuitarType = GuitarEnum.ACOUSTIC, Price = 3000,
                Description =
                    "The Martin D-28 is a legendary acoustic guitar celebrated for its rich, full-bodied sound and impeccable build quality. Featuring a solid Sitka spruce top and East Indian rosewood back and sides, the D-28 delivers deep bass, clear highs, and a well-balanced midrange that's perfect for a wide range of musical styles and playing techniques. Its comfortable low-profile neck, traditional dovetail neck joint, and hand-scalloped bracing contribute to its exceptional tone and resonance. The Martin D-28's iconic status, superb craftsmanship, and timeless design make it a prized instrument among professional musicians and collectors alike."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1230534710/photo/a-gibson-slash-collection-j-45-standard-electro-acoustic-guitar-taken-on-january-10-2020.jpg?s=612x612&w=0&k=20&c=F_7ixefS3wv4jCoAjbQG2nJ63Ahg4NJrERV3LtquQkA="
                ],
                Name = "Gibson J-45 Standard", GuitarType = GuitarEnum.ACOUSTIC, Price = 2500,
                Description =
                    "The Gibson J-45 Standard is a classic acoustic guitar known for its warm, mellow tone and unmatched projection. Featuring a solid Sitka spruce top and mahogany back and sides, the J-45 delivers rich, resonant acoustic sound with a balanced mix of clarity and depth. Its comfortable round-shoulder body shape and advanced X-bracing pattern enhance its sonic performance and sustain, making it a favorite among singer-songwriters and acoustic enthusiasts. The Gibson J-45 Standard's timeless design, premium materials, and legendary craftsmanship ensure its place as a cornerstone of acoustic guitar history."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/977577294/photo/a-yamaha-a3r-are-electro-acoustic-guitar-and-a-yamaha-a5r-are-electro-acoustic-guitar-taken-on.jpg?s=612x612&w=0&k=20&c=aADeNOrYvQzt6z5INzYaPH51LrXWYSqJo40DBUOsI-U="
                ],
                Name = "Yamaha FG800", GuitarType = GuitarEnum.ACOUSTIC, Price = 200,
                Description =
                    "The Yamaha FG800 is an affordable acoustic guitar renowned for its solid construction and clear, bright sound. Featuring a solid spruce top and nato/okume back and sides, the FG800 offers a balanced tone with strong midrange projection and crisp treble response. Its comfortable dreadnought body shape and smooth satin finish make it a comfortable and attractive option for beginners and experienced players alike. The Yamaha FG800's reliability, affordability, and quality craftsmanship have made it a popular choice for those seeking a dependable acoustic guitar without breaking the bank."
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1087036226/photo/a-seagull-s6-original-acoustic-guitar-taken-on-january-9-2018.jpg?s=612x612&w=0&k=20&c=JdbwNV5TdsX6mli64hAqvQcV_M0C60DcltbTOOZ9bzM="
                ],
                Name = "Seagull S6 Original", GuitarType = GuitarEnum.ACOUSTIC, Price = 500,
                Description =
                    "The Seagull S6 Original is a handcrafted Canadian acoustic guitar known for its rich tone and excellent playability. Featuring a pressure-tested solid cedar top and wild cherry back"
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1087036216/photo/detail-of-a-seagull-s6-original-acoustic-guitar-taken-on-january-8-2018.jpg?s=612x612&w=0&k=20&c=36T8zqZs42fgc1nOxVQfm_F2r8XrwKQIPO183E2hjw0="
                ],
                Name = "Martin LX1 Little Martin", GuitarType = GuitarEnum.ACOUSTIC, Price = 400
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/143378091/photo/taylor-114ce-and-210ce-electro-acoustic-guitars-during-a-studio-shoot-for-guitarist-magazine.jpg?s=612x612&w=0&k=20&c=smKdecmcaTb5fjRjnqomrDtndETDoc1UTqeJZVpuH9k="
                ],
                Name = "Taylor 114ce", GuitarType = GuitarEnum.ACOUSTIC, Price = 900
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/886988440/photo/a-group-of-baritone-electro-acoustic-guitars-including-a-taylor-326e-alvarez-artist-series.jpg?s=612x612&w=0&k=20&c=8wVMFqCcFoD6tetvPV0oEA_jOYM8gYD3BVWsvQq72bk="
                ],
                Name = "Alvarez Artist Series AD60", GuitarType = GuitarEnum.ACOUSTIC, Price = 400
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/98557645/photo/los-angeles-guitarist-innovator-and-inventor-del-casher-poses-for-a-portrait-in-los-angeles.jpg?s=612x612&w=0&k=20&c=nsndmW2gULyezkHsHEaNWPnEFLEsZ3KoOuqOfIR9FxM="
                ],
                Name = "Washburn WD10SCE", GuitarType = GuitarEnum.ACOUSTIC, Price = 300
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1238182391/photo/a-yamaha-sa2200-and-yamaha-sg1820-electric-guitar-taken-on-november-11-2020.jpg?s=612x612&w=0&k=20&c=pkIGJs6A1572pnD3SPcMqoirUE4qgqTJKUkPVAmlFB0="
                ],
                Name = "Yamaha LL-TA TransAcoustic", GuitarType = GuitarEnum.ACOUSTIC, Price = 1500
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1229286773/photo/a-vintage-1962-fender-precision-electric-bass-guitar-taken-on-october-4-2019.jpg?s=612x612&w=0&k=20&c=PXCbSQsQaTDr4guaWl9U8ERo68BZAL5c4X2loEMOy3k="
                ],
                Name = "Fender Precision Bass", GuitarType = GuitarEnum.BASS, Price = 1100
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1300506322/photo/cream-music-man-stingray-bass-guitar.jpg?s=612x612&w=0&k=20&c=I3BDZ6LGrltfSF1ydqEuu_ycjQRUguCsBOuWJC_x3GI="
                ],
                Name = "Music Man StingRay", GuitarType = GuitarEnum.BASS, Price = 1800
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/143511871/photo/an-ibanez-btb475-five-string-bass-guitar-during-a-studio-shoot-for-guitarist-magazine-future.jpg?s=612x612&w=0&k=20&c=a_KDMaP8hDfxdjF4tPJ8-ft-4plSiyH9-XQrYx6MTig="
                ],
                Name = "Ibanez SR505", GuitarType = GuitarEnum.BASS, Price = 900
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/544010928/photo/santa-fe-nm-veteran-blues-musician-greg-rzab-plays-his-fender-jazz-bass-guitar-on-stage-with.jpg?s=612x612&w=0&k=20&c=uUmnJ7AX1P-XRjFKqhVIPCQFtg-jcQ4BkWJOj4yGURY="
                ],
                Name = "Fender Jazz Bass", GuitarType = GuitarEnum.BASS, Price = 1500
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/1229286618/photo/a-vintage-1966-gibson-eb-2-electric-bass-guitar-taken-on-october-4-2019.jpg?s=612x612&w=0&k=20&c=XSooyPhDs6JxgpVMzIvSQH-BKTt_3c3U2yx7fBQAyB4="
                ],
                Name = "Gibson SG Standard Bass", GuitarType = GuitarEnum.BASS, Price = 1800
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/88514441/photo/american-jazz-musician-stanley-clarke-performs-on-stage-at-the-guitar-legends-concert-in.jpg?s=612x612&w=0&k=20&c=Mdh881xk2RmS5DzDOrZxgfPCQA2O-jakJAnYyTOQRgw="
                ],
                Name = "ESP LTD EC-1000", GuitarType = GuitarEnum.BASS, Price = 1000
            },
            new SellableProduct
            {
                Images =
                [
                    "https://media.gettyimages.com/id/467405016/photo/a-schecter-hellraiser-hybrid-c-1-fr-electric-guitar-taken-on-july-1-2014.jpg?s=612x612&w=0&k=20&c=tm8TXrds9YnGaFzC_VJiSKrxHNnwGtj5_lftZMynqfI="
                ],
                Name = "Schecter Hellraiser C-1", GuitarType = GuitarEnum.BASS, Price = 1200
            }
        ];

        List<Manufacturer> manufacturers =
        [
            new Manufacturer { Name = "Gibson", Country = "USA", Description = "Placeholder" },
            new Manufacturer { Name = "Ibanez", Country = "Japan", Description = "Placeholder" },
            new Manufacturer { Name = "Fender", Country = "Germany", Description = "Placeholder" }
        ];

        manufacturers.ForEach(manufacturer =>
        {
            context.Manufacturers.Add(manufacturer);
            context.SaveChanges();
        });


        products.ForEach(prod =>
        {
            var manufacturer = manufacturers.Find(m => prod.Name.Contains(m.Name));

            context.SellableProduct.Add(prod);
            prod.Manufacturers.Add(manufacturer ?? manufacturers[2]);
            context.SaveChanges();
        });

        stores.ForEach(store =>
        {
            context.Stores.Add(store);
            context.SaveChanges();

            products.ForEach(prod =>
            {
                context.ProductStores.Add(new ProductStore { ProductId = prod.Id, StoreId = store.Id, Quantity = 3 });
                context.SaveChanges();
            });
        });
    }
}