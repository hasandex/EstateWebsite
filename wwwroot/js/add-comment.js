function addComment(estateId) {
    // Get the comment content from the user input
    var commentContent = $("#commentContent").val();

    $.ajax({
        type: "POST",
        url: "/User/AddComment",
        data: { content: commentContent, userId: "@User.Id", estateId: estateId },
        success: function (result) {
            if (result.success) {
                // Clear the comment input
                $("#commentContent").val("");

                // Add the new comment to the UI
                var newCommentHtml = `
                    <div id="comment-${result.commentId}" class="overflow-hidden d-flex mt-4" style="gap:10px; width: 100%;">
                        <div style="width: 50px;height: 50px;border-radius: 50%;overflow: hidden;border: 3px solid white;flex-shrink: 0;">
                            <img src="@Url.Content("~/assets/cover.png")" style="height:100%; width: 100%;" alt="profile">
                        </div>
                        <div class="w-50 d-flex" style="gap:40px">
                            <p class="mt-1" style="word-break: break-all;">
                                <strong>@User.FName -</strong>
                                <span class="text-muted">${new Date().toLocaleDateString()}</span>
                                <br />
                                ${commentContent}
                            </p>
                            <div class="dropdown">
                                <button class="btn btn-xs btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton${result.commentId}" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fas fa-ellipsis-v"></i>
                                </button>
                                <ul class="dropdown-menu dropdown-menu-xs dropdown-menu-end" aria-labelledby="dropdownMenuButton${result.commentId}">
                                    <li><a class="dropdown-item" href="#" onclick="deleteComment('${result.commentId}')">Delete</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                `;

                $("#comments-container").append(newCommentHtml);
            } else {
                // Display the errors from the server-side
                alert("Error adding comment: " + result.errors.join(", "));
            }
        },
        error: function (xhr, status, error) {
            // Handle any errors that occurred during the addition
            console.log("Error adding comment: " + error);
        }
    });
}