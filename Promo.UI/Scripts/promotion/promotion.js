$(document).ready(function () {
    $('.date').prop('readOnly', true);
    $('.date').datepicker({
        dateFormat: 'dd.mm.yy',
        minDate: '1.1.2010',
    });
    $.ajax({
        url: "/api/GetPublishedBrands",
        cache: false,
        success: function (results) {
            $(".js-brands-data-array").select2({
                data: results,
                multiple: true
            });
            $.ajax({
                url: "/api/GetPromotionBrands?promotionId=" + $("#Promotion_PromotionId").val(),
                cache: false,
                success: function (results) {
                    $.each(results, function (i, item) {
                        $('#BrandIds option[value=' + results[i] + ']').attr('selected', true);
                    });
                    $("#BrandIds").trigger("change");
                }
            })
        }
    })
    
    $.ajax({
        url: "/api/GetStoresByCompanyForJson?companyId=" + $("#Promotion_CompanyId option:selected").val(),
        cache: false,
        success: function (results) {
            $(".js-stores-data-array").select2({
                data: results,
                multiple: true
            });
            $.ajax({
                url: "/api/GetPromotionStores?promotionId=" + $("#Promotion_PromotionId").val(),
                cache: false,
                success: function (results) {
                    $.each(results, function (i, item) {
                        $('#StoreIds option[value=' + results[i] + ']').attr('selected', true);
                    });
                    $("#StoreIds").trigger("change");
                }
            })
        }
    })
});
