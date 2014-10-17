$(document).ready(function () {



//Show and hide comments
$('.showcomments').on('click', function () {
    var parent = $(this).parent();
    var commentsToShowOrHide = parent.find('.commentsDiv');
    commentsToShowOrHide.SlideToggle();
});


//handle the like button
$('.like').on('click', function () {
    //what post does the user want to like
    var postID = $(this).data('postid');
    //store the this element into a variable
    var theLikeButton = $(this);
    //do the AJAX get request to like the post
    $.get('/Home/LikePost/' + postID, function (data) {
    //need to update the html with the current number of likes
    theLikeButtons.parent().html(data);
});
});

//wire up the AJAX post for the comment form
$('.commentsDiv').on('Submit', function () {
    //prevent the form from posting
    event.preventDefault();
    var theForm = $(this);
    $.post(theForm.attr('action'), theForm.serialize(data), function (data) {
        //update the html
        theForm.before(data);
        theForm.find('.commentAuthor, .commenbody').val('');
    });
});
    
});