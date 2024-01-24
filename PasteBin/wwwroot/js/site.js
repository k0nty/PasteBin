document.getElementById("createPaste").addEventListener("click", () => { 
    var title = $("#pasteTitle").val();
    var content = $("#pasteContent").val();

    $.ajax({
        url: "/Home/AddPaste",
        type: "POST",
        data: { Title: title, Content: content },
        success: function (result) {
            if (result.success) {
                alert(result.message);
            } else {
                alert("Error creating paste: " + result.message);
            }
        },
        error: function (error) {
            alert("Error creating paste: " + error.responseText);
        }
    });
})