using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Model.Request
{

    public class ImportProductsRequest
    {
        public List<Product> ProductList;

    }

    public class Product
    {
        public string IntegrationId { get; set; }
        public string BaseProductCode { get; set; }
        public string ColorVariantCode { get; set; }
        public string Sku { get; set; }
        public string StockAmount { get; set; }
        public string Ean { get; set; }
        public string TaxRate { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string MainCategory { get; set; }
        public string FirstSellingVat { get; set; }
        public string LastSellingVat { get; set; }
        public string Color { get; set; }
        public string Image1Link { get; set; }
        public string Image2Link { get; set; }
        public string Image3Link { get; set; }
        public string Image4Link { get; set; }
        public string Image5Link { get; set; }
        public string WebCategory { get; set; }
        public string Store { get; set; }
        public string IsDeleted { get; set; }
        public string IsUnpublished { get; set; }

        public string Variant3 { get; set; }
        public string Variant4 { get; set; }
        public string Filter3 { get; set; }
        public string Filter4 { get; set; }
        public string Filter5 { get; set; }
        public string Filter6 { get; set; }
    }

    /*MAPPER*/

    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Map(m => m.IntegrationId).Ignore();
            Map(m => m.BaseProductCode).Name("base_product_code");
            Map(m => m.ColorVariantCode).Name("color_variant_code");
            Map(m => m.Sku).Name("sku");
            Map(m => m.StockAmount).Name("stock_amount");
            Map(m => m.Ean).Name("ean");
            Map(m => m.TaxRate).Name("taxrate");
            Map(m => m.Size).Name("size");
            Map(m => m.Title).Name("title");
            Map(m => m.Headline).Ignore();
            Map(m => m.Description).Name("product_description");
            Map(m => m.MainCategory).Name("main_category");
            Map(m => m.FirstSellingVat).Name("first_selling_vat");
            Map(m => m.LastSellingVat).Name("lastsellingvat");
            Map(m => m.Color).Name("color");
            Map(m => m.Image1Link).Name("image1_link");
            Map(m => m.Image2Link).Name("image2_link");
            Map(m => m.Image3Link).Name("image3_link");
            Map(m => m.Image4Link).Name("image4_link");
            Map(m => m.Image5Link).Name("image5_link");
            Map(m => m.WebCategory).Name("web_category");
            Map(m => m.Store).Ignore();
            Map(m => m.IsDeleted).Ignore();
            Map(m => m.IsUnpublished).Ignore();

            Map(m => m.Variant3).Ignore();
            Map(m => m.Variant4).Ignore();
            Map(m => m.Filter3).Ignore();
            Map(m => m.Filter4).Ignore();
            Map(m => m.Filter5).Ignore();
            Map(m => m.Filter6).Ignore();



        }

    }

}