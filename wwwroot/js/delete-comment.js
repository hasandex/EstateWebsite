function deleteComment(commentId) {
    $.ajax({
        type: "POST",
        url: "/User/RemoveComment",
        data: { commentId: commentId },
        success: function (result) {
            // Remove the comment from the UI
            $(`#comment-${commentId}`).remove();
            // Show a success message or perform any other necessary actions
            console.log("Comment deleted successfully.");
        },
        error: function (xhr, status, error) {
            // Handle any errors that occurred during the deletion
            console.log("Error deleting comment: " + error);
        }
    });
}
