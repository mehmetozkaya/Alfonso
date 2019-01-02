using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Models;

namespace Alfonso.Services
{
    public class TelefonService : ITelefonService
    {
        public List<Telefon> GetTelefons()
        {
            return new List<Telefon>()
            {
                new Telefon()
                {
                    Id = 1,
                    Slug = "uphone-x",
                    Name = "UPhone X",
                    Category = "Smartphone",
                    Star = 4.4,
                    Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-52.png",
                    MainSpecs = new List<string>
                    {
                        "Intel Core i7 Processor",
                        "Zeon Z 170 Pro Motherboad",
                        "16 GB RAM"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature
                        {
                            FeatureType = FeatureType.Network,
                            Name = "Technology",
                            Value = "GSM / CDMA / HSPA"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Launch,
                            Name = "Announced",
                            Value = "2018, September"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Launch,
                            Name = "Status",
                            Value = "Available. Released 2018, September"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Body,
                            Name = "Dimensions",
                            Value = "157.5 x 77.4 x 7.7 mm (6.20 x 3.05 x 0.30 in)"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Body,
                            Name = "Weight",
                            Value = "208 g (7.34 oz)"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Body,
                            Name = "Build",
                            Value = "Front/back glass, stainless steel frame"
                        },
                        new Feature
                        {
                            FeatureType = FeatureType.Body,
                            Name = "SIM",
                            Value = "Single SIM (Nano-SIM) or Dual SIM (Nano-SIM, dual stand-by)"
                        }
                    }
                },
                new Telefon()
                {
                    Id = 2,
                    Slug = "uawai-nova-i2",
                    Name = "Uawei Nova i2",
                    Category = "Smartphone",
                    Star = 4.2,
                    Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-53.png",
                    MainSpecs = new List<string>
                    {
                        "Intel Core i7 Processor",
                        "Zeon Z 170 Pro Motherboad",
                        "16 GB RAM"
                    }
                },
                new Telefon()
                {
                    Id = 3,
                    Slug = "samsome-galaxy-s9",
                    Name = "Samsome Galaxy S9",
                    Category = "Smartphone",
                    Star = 4.6,
                    Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-17.png",
                    MainSpecs = new List<string>
                    {
                        "Intel Core i7 Processor",
                        "Zeon Z 170 Pro Motherboad",
                        "16 GB RAM"
                    }
                },
                 new Telefon()
                {
                    Id = 4,
                    Slug = "gl-stylus-4",
                    Name = "GL Stylus 4",
                    Category = "Smartphone",
                    Star = 4.6,
                    Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-54.png",
                    MainSpecs = new List<string>
                    {
                        "Intel Core i7 Processor",
                        "Zeon Z 170 Pro Motherboad",
                        "16 GB RAM"
                    }
                }
            };
        }
    }
}
