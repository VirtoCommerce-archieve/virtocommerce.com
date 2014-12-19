$(function () {
	var seoContent = {
		"1": "VG8gbGVhcm4gbW9yZSBhYm91dCBFbnRlcnByaXNlIGVkaXRpb24gcHJpY2luZywgcGxlYXNlIGNvbXBsZXRlIHRoZSBicmllZiBmb3JtIGFuZCB3ZSB3aWxsIGJlIGluIGNvbnRhY3Qgd2l0aCB5b3Ugc2hvcnRseQ==",
		"2": "VG8gbGVybiBtb3JlIGFib3V0IENvbW11bml0eSBFZGl0aW9uLCBwbGVhc2UgY29tcGxldGUgdGhlIGJyaWVmIGZyb21lIGJlbG93IGFuZCB3ZSB3aWxsIGJlIGluIGNvbnRhY3Qgd2l0aCB5b3Ugc2hvcnRseQ=="
	};
	var seoHrefs = {
		"1": "L3RyeS1ub3c=",
		"2": "L3RyeS1ub3c=",
		"3": "L3RyeS1ub3c=",
		"4": "L3RyeS1ub3c=",
	};
	var $elements = $("[id*='href'],[id*='cont']");
	for (var i = 0; i < $elements.length; i++) {
		var $element = $elements.eq(i);
		var id = $element.attr("id");
		var type = id.substring(0, 4);
		var key = id.substring(5, id.length);
		switch (type) {
			case "href":
				$element.attr("href", Base64.decode(seoHrefs[key]));
				break;
			case "cont":
				$element.html(Base64.decode(seoContent[key]));
				break;
		}
	}
	$(document).trigger("renderpage.finish");
});