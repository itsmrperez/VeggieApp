veggie.services.recipe = veggie.services.recipe || {};
veggie.services.recipe.baseUrl = "/api/recipe"

veggie.services.recipe.getAll = function (onSuccess, onError) {
    var url = veggie.services.recipe.baseUrl
	var settings =
		{
			cache: false
			, contentType: "application/json"
			, dataType: "json"
			, type: "GET"
			, xhrFields:
				{
					withCredentials: true
				}
			, success: onSuccess
			, error: onError
		}
	$.ajax(url, settings)
}

veggie.services.recipe.getById = function (id, onSuccess, onError) {
    var url = veggie.services.recipe.baseUrl + id
	var settings =
		{
			cache: false
			, contentType: "application/json"
			, dataType: "json"
			, type: "GET"
			, xhrFields:
				{
					withCredentials: true
				}
			, success: onSuccess
			, error: onError
		}
	$.ajax(url, settings)
}