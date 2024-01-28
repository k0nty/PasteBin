document.getElementById("createPaste").addEventListener("click", () => { 
    var title = $("#pasteTitle").val();
    var content = $("#pasteContent").val();

    $.ajax({
        url: "/Home/AddPaste",
        type: "POST",
        data: { Title: title, Content: content },
        success: function (result) {
            if (result.success) {
                console.log(result.message);
                if (result.link) {
                    console.log("Created paste link: " + result.link);

                    // Вставити посилання у відповідний елемент HTML
                    $("#createdPasteLink #pasteLink").attr("href", result.link).text(result.link);
                    $("#createdPasteLink").show();
                }
            } else {
                console.log("Error creating paste: " + result.message);
            }
        },
        error: function (xhr) {
            if (xhr.status == 401) {
                alert("Unauthorized. Redirecting to login page.");
            }
        },
    });
})