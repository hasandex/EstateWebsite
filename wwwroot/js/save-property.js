function savePro(estateId) {
    $.ajax({
        type: "POST",
        url: "/User/SaveProperty",
        data: { estateId: estateId },
        success: function (result) {
            // Remove the comment from the UI
            // Show a success message or perform any other necessary actions
            console.log("property saved successfully.");
        },
        error: function (xhr, status, error) {
            // Handle any errors that occurred during the deletion
            console.log("Error saved property: " + error);
        }
    });
}
