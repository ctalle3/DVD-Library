var indexPageDivId = "#index-div";
var editPageDivId = "#edit-div";
var createPageDivId = "#create-div";
var displayPageDivId = "#display-div";

var grabDVDGridContainer = "#dvd-grid";

// home page id's
var createButtonId = "#create";
var searchButtonId = "#search";
var categoryDropDownId = "#category";
var searchTermInputId = "#search-term";
var headerIndexPageId = "#header";
var htmlBody = "body";

// create page id's
var createDVDButtonId = "#create-dvd";
var cancelButtonCreatePageId = "#create-cancel";
var createTitleId = "#create-title";
var createReleaseYearId = "#create-release-year";
var createDirectorId = "#create-director";
var createRatingId = "#create-rating";
var createNotesId = "#create-notes";

// edit page id's
var editSaveChangesButtonId = "#edit-save";
var editCancelButtonId = "#edit-cancel";
var editTitleId = "#edit-title";
var editReleaseYearId = "#edit-release-year";
var editDirectorId = "#edit-director";
var editRatingId = "#edit-rating";
var editNotesId = "#edit-notes";

// display page id's
var displayBackButtonId = "#display-back";
var displayHeaderId = "#display-header";
var displayTitleId = "#display-title";
var displayReleaseYearId = "#display-release-year";
var displayDirectorId = "#display-director";
var displayRatingId = "#display-rating";
var displayNotesId = "#display-notes";

// input data variables for post
var titlePostOrPut;
var releaseYearPostOrPut;
var directorPostOrPut;
var ratingPostOrPut;
var notesPostOrPut;

$(document).ready(function () {
    $(displayPageDivId).hide();
    $(editPageDivId).hide();
    $(createPageDivId).hide();

    $.ajax({
        url: "http://localhost:54936/dvds",
        type: "GET",
        success: function (result) {

            // gets movie info and creates a dynamic table
            $.each(result, function (index, value) {

                var movieRowDiv = '<div id="row-item-' + index + '"class="product row"></div>';
                var rowItemId = "#row-item-" + index;

                var title = '<td id="title-' + index + '" class="col-3">' + result[index].title + '</td>';
                var releaseYear = '<td id="release-date-' + index + '" class="col-2">' + result[index].releaseYear + '</td>';
                var director = '<td id="director-' + index + '" class="col-3">' + result[index].director + '</td>';
                var rating = '<td id="rating-' + index + '" class="col-2">' + result[index].rating + '</td>';

                var editButton = '<button id="edit-button-' + index + '" class="col-1" type="button">Edit</button>';
                var editButtonId = "#edit-button-" + index;
                var deleteButton = '<button id="delete-button-' + index + '" class="col-1" type="button">Delete</button>';
                var deleteButtonId = "#delete-button-" + index;

                $(grabDVDGridContainer).append(movieRowDiv);

                $(rowItemId).append(title);
                $(rowItemId).append(releaseYear);
                $(rowItemId).append(director);
                $(rowItemId).append(rating);
                $(rowItemId).append(editButton);
                $(rowItemId).append(deleteButton);

                // edit button onclick binding
                $(grabDVDGridContainer).on('click', editButtonId, function () {

                    dvdIndex = editButtonId.slice(13);

                    $.ajax({
                        url: "http://localhost:54936/dvds",
                        type: "GET",
                        success: function (result) {                          
                            $(indexPageDivId).hide();
                            $(editPageDivId).show();                            
                            // have a second onclick that saves changes by doing a GET and then a PUT.
                            $.ajax({
                                url: "http://localhost:54936/dvd/" + result[dvdIndex].dvdId,
                                type: "GET",
                                success: function (result) {
                                    $(editTitleId).val(result.title);
                                    $(editReleaseYearId).val(result.releaseYear);
                                    $(editDirectorId).val(result.director);
                                    $(editRatingId).val(result.rating);
                                    $(editNotesId).val(result.notes);
                                    $(editSaveChangesButtonId).attr("value", result.dvdId);
                                }
                            })
                        },
                        error: function (result) {
                            alert("Good try.");
                        }
                    })
                });

                // delete button onclick binding
                $(grabDVDGridContainer).on('click', deleteButtonId, function () {
                    $.ajax({
                        url: "http://localhost:54936/dvds",
                        type: "GET",
                        success: function (result) {
                            dvdIndex = deleteButtonId.slice(15);

                            if (confirm("Are you sure you want to delete this DVD from your collection?")) {
                                $.ajax({
                                    url: "http://localhost:54936/dvd/" + result[dvdIndex].dvdId,
                                    type: "DELETE"
                                })
                                setTimeout(function () { location.reload() }, 100);
                            }
                            else {
                                return false;
                            }
                        },
                        error: function (result) {
                            alert("Good try.")
                        }
                    })
                });
            })
        },
        error: function (result) {
            alert("Nice try.");
        }
    })
});   

// create onclick event index page
$(headerIndexPageId).on('click', createButtonId, function () {
    $(indexPageDivId).hide();
    $(createPageDivId).show();
});

// search onclick event index page
$(headerIndexPageId).on('click', searchButtonId, function () {

    var searchCategory = $("#category").val();

    var searchUserInput = $("#search-term").val();

    if (searchUserInput.length == 0 || searchCategory == null) {
        $("#search-error").empty().append("Please choose a category and enter a search value.");
        $("#search-error").show();
    }
    else {
        $("#search-error").hide();
        searchCategory = searchCategory.toUpperCase();

        switch (searchCategory) {
            case "TITLE":
                searchFor = "title/" + searchUserInput;
                break;
            case "RELEASE-YEAR":
                searchFor = "year/" + searchUserInput;
                break;
            case "DIRECTOR":
                searchFor = "director/" + searchUserInput;
                break;
            case "RATING":
                searchFor = "rating/" + searchUserInput;
                break;
            default:
                searchFor = "";
        }
        $(grabDVDGridContainer).empty();

        $.ajax({
            url: "http://localhost:54936/dvds/" + searchFor,
            type: "GET",
            success: function (result) {

                // gets movie info and creates a dynamic table
                $.each(result, function (index, value) {

                    var movieRowDiv = '<div id="row-item-' + index + '"class="product row"></div>';
                    var rowItemId = "#row-item-" + index;

                    var title = '<td id="title-' + index + '" class="col-3">' + result[index].title + '</td>';
                    var releaseYear = '<td id="release-date-' + index + '" class="col-2">' + result[index].releaseYear + '</td>';
                    var director = '<td id="director-' + index + '" class="col-3">' + result[index].director + '</td>';
                    var rating = '<td id="rating-' + index + '" class="col-2">' + result[index].rating + '</td>';

                    var editButton = '<button id="edit-button-' + index + '" class="col-1" type="button">Edit</button>';
                    var editButtonId = "#edit-button-" + index;
                    var deleteButton = '<button id="delete-button-' + index + '" class="col-1" type="button">Delete</button>';
                    var deleteButtonId = "#delete-button-" + index;

                    $(grabDVDGridContainer).append(movieRowDiv);

                    $(rowItemId).append(title);
                    $(rowItemId).append(releaseYear);
                    $(rowItemId).append(director);
                    $(rowItemId).append(rating);
                    $(rowItemId).append(editButton);
                    $(rowItemId).append(deleteButton);

                    // edit button onclick binding
                    $(grabDVDGridContainer).on('click', editButtonId, function () {

                        dvdIndex = editButtonId.slice(13);

                        $.ajax({
                            url: "http://localhost:54936/dvds",
                            type: "GET",
                            success: function (result) {
                                $(indexPageDivId).hide();
                                $(editPageDivId).show();

                                $.ajax({
                                    url: "http://localhost:54936/dvd/" + result[dvdIndex].dvdId,
                                    type: "GET",
                                    success: function (result) {
                                        $(editTitleId).val(result.title);
                                        $(editReleaseYearId).val(result.releaseYear);
                                        $(editDirectorId).val(result.director);
                                        $(editRatingId).val(result.rating);
                                        $(editNotesId).val(result.notes);
                                        $(editSaveChangesButtonId).attr("value", result.dvdId);
                                    }
                                })
                            },
                            error: function (result) {
                                alert("Good try.");
                            }
                        })
                    });

                    // delete button onclick binding
                    $(grabDVDGridContainer).on('click', deleteButtonId, function () {
                        $.ajax({
                            url: "http://localhost:54936/dvds",
                            type: "GET",
                            success: function (result) {
                                dvdIndex = deleteButtonId.slice(15);

                                if (confirm("Are you sure you want to delete this DVD from your collection?")) {
                                    $.ajax({
                                        url: "http://localhost:54936/dvd/" + result[dvdIndex].dvdId,
                                        type: "DELETE"
                                    })
                                    setTimeout(function () { location.reload() }, 100);
                                }
                                else {
                                    return false;
                                }
                            },
                            error: function (result) {
                                alert("Good try.")
                            }
                        })
                    });
                })
            },
            error: function (result) {
                alert("Isn't working.");
            }
        })
    }
});

// creates new dvd
$(htmlBody).on('click', createDVDButtonId, function () {
    
    titlePostOrPut = $(createTitleId).val();
    releaseYearPostOrPut = $(createReleaseYearId).val();
    directorPostOrPut = $(createDirectorId).val();
    ratingPostOrPut = $(createRatingId).val();
    notesPostOrPut = $(createNotesId).val();

    var intYear = parseInt(releaseYearPostOrPut);
    var lengthYear = 4;
    var maxYear = 2020;
    var minYear = 1850;

    if (titlePostOrPut.length == 0) {
        $("#create-error").empty().append("Please enter a title.");
        $("#create-error").show();
    }
    else if (releaseYearPostOrPut.length != lengthYear ||  intYear >= maxYear || intYear <= minYear) {
        $("#create-error").empty().append("Please enter a valid date.");
        $("#create-error").show();
    }
    else if (directorPostOrPut.length == 0) {
        $("#create-error").empty().append("Please enter the director.");
        $("#create-error").show();
    }
    else if (ratingPostOrPut == null) {
        $("#create-error").empty().append("Please enter the DVD rating.");
        $("#create-error").show();
    }
    else {

        ratingPostOrPut = ratingPostOrPut.toUpperCase();
        $("#create-error").hide();    
            $.ajax({
                url: "http://localhost:54936/dvd",
                type: "POST",
                data: JSON.stringify({ title: titlePostOrPut, releaseYear: releaseYearPostOrPut, director: directorPostOrPut, rating: ratingPostOrPut, notes: notesPostOrPut }),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                success: function (result) {

                    $("#create-div").hide();
                    $("#display-div").show();

                    $(displayHeaderId).val(JSON.stringify(result.title));
                    $(displayTitleId).val(JSON.stringify(result.title));
                    $(displayReleaseYearId).val(JSON.stringify(result.releaseYear));
                    $(displayDirectorId).val(JSON.stringify(result.director));
                    $(displayRatingId).val(JSON.stringify(result.rating));
                    $(displayNotesId).val(JSON.stringify(result.notes));
                },
                error: function (result) {
                    alert("Won't work.");
                }
            })
    } 
});

// cancels new dvd creation and returns to the home page
$(htmlBody).on('click', cancelButtonCreatePageId, function () {

    $(createPageDivId).hide();
    $(indexPageDivId).show();
});

$(htmlBody).on('click', editCancelButtonId, function () {

    $(editPageDivId).hide();
    $(indexPageDivId).show();
});


// edits dvd
$(htmlBody).on('click', editSaveChangesButtonId, function () {

    titlePostOrPut = $(editTitleId).val();
    releaseYearPostOrPut = $(editReleaseYearId).val();
    directorPostOrPut = $(editDirectorId).val();
    ratingPostOrPut = $(editRatingId).val();
    notesPostOrPut = $(editNotesId).val();
    dvdId = $(editSaveChangesButtonId).attr("value");

    var intYear = parseInt(releaseYearPostOrPut);
    var lengthYear = 4;
    var maxYear = 2020;
    var minYear = 1850;

    if (titlePostOrPut.length == 0) {
        $("#edit-error").empty().append("Please enter a title.");
        $("#edit-error").show();
    }
    else if (releaseYearPostOrPut.length != lengthYear || intYear >= maxYear || intYear <= minYear) {
        $("#edit-error").empty().append("Please enter a valid date.");
        $("#edit-error").show();
    }
    else if (directorPostOrPut.length == 0) {
        $("#edit-error").empty().append("Please enter the director.");
        $("#edit-error").show();
    }
    else if (ratingPostOrPut == null) {
        $("#edit-error").empty().append("Please enter the DVD rating.");
        $("#edit-error").show();
    }
    else {

        ratingPostOrPut = ratingPostOrPut.toUpperCase();
        $("#edit-error").hide();
        
        $.ajax({
            url: "http://localhost:54936/dvd/" + dvdId,
            type: "PUT",
            data: JSON.stringify({ dvdId: dvdId, title: titlePostOrPut, releaseYear: releaseYearPostOrPut, director: directorPostOrPut, rating: ratingPostOrPut, notes: notesPostOrPut }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
        $(editPageDivId).hide();
        $(indexPageDivId).show();
        setTimeout(function () { location.reload() }, 100);
    }
});

// display page back button
$(htmlBody).on('click', displayBackButtonId, function () {
    $(displayPageDivId).hide();
    $(indexPageDivId).show();
    setTimeout(function () { location.reload() }, 100);
});