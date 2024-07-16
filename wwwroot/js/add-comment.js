function addComment(estateId) {
    // Get the comment data
    var commentContent = document.getElementById('commentContent').value;
    var userId = document.getElementById('userId').value;
    var userPic = document.getElementById('userPic').value;
    var userFName = document.getElementById('userFName').value;
    var currentDate = new Date();
    //get the div that we will add the comment in
    var commentContainer = document.getElementById('commentContainer');

    $.ajax({
        type: "POST",
        url: "/User/AddComment",
        data: { content: commentContent, userId: userId, estateId: estateId },
        success: function (result) {
            if (result.success) {
                // cleat the comment from its input
                $("#commentContent").val("");
                
                // create the new comment html
                var newCommentHtml = `
                    <div id="comment-${result.commentId}" class="card mb-4">
                            <div class="card-body">
                                <div class="d-flex align-items-center mb-3">
                                    <div class="profile-pic me-3">
                                            <img style="width:50px;height:50px" src="/assets/night.jpg" class="rounded-circle" alt="profile">
                                    </div>
                                    <div>
                                        <h6 class="mb-0">${userFName}</h6>
                                        <small class="text-muted">${currentDate.toLocaleDateString('en-US', { month: 'long', year: 'numeric' }) }</small>
                                    </div>
                              
                                        <div class="ms-auto">
                                            <div class="dropdown">
                                                <button class="btn btn-sm btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton${result.commentId}" data-bs-toggle="dropdown" aria-expanded="false">
                                                    <i class="fas fa-ellipsis-v"></i>
                                                </button>
                                                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="dropdownMenuButton${result.commentId}">
                                                    <li><a class="dropdown-item" onclick="deleteComment('${result.commentId}')">Delete</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    
                                </div>
                                <p class="card-text">${commentContent}</p>
                            </div>
                        </div>
                `;
                //create div element to put the new elemen in, and then insert this div in the elements container
                var tempDiv = document.createElement('div');
                tempDiv.innerHTML = newCommentHtml.trim();
                var commentElement = tempDiv;
                //insert the comment div in the container
                commentContainer.insertBefore(commentElement, commentContainer.firstChild);
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