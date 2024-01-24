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
            } else {
                console.log("Error creating paste: " + result.message);
            }
        },
        error: function (error) {
            console.log("Error creating paste: " + error.responseText);
        }
    });
})