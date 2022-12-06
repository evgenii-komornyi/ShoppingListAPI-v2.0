namespace Models.Errors
{
    public enum ProductValidationErrors
    {
        Empty_name,
        Empty_brand,
        Brand_length_violation,
        Empty_price,
        Empty_category,
        Name_length_violation,
        Duplicate_name,
        Negative_or_zero_price,
        Discount_application_limit_violation,
        Invalid_discount_range,
        Description_length_violation,
        No_search_criteria,
        Conflict_params,
        No_update_criteria,
        Conflict_update_params,
        Empty_id,
        Filename_format_violation,
        Product_Not_Found
    }
}
