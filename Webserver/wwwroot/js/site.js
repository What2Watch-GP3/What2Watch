// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Do some Ajax load of movies
$(document).ready(function () {

    //potential code for making the whole table row clickable, not just the movie name.
    /*$("#search-test").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#movies-table tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    //grabs the movie table and the a href from the table cell and applies it to the whole cell.
    if (document.getElementById("movies-table") != null)
    {
        const rows = document.getElementById("movies-table").children;
        for (let i = 0; i < rows.length; i++) {
            const row = rows[i];
            //console.log(row);
            //console.log(row.children[0].children[0].getAttribute("href"));
            //console.log(row.firstChild.children().find('a').attr("href"));

            row.addEventListener("click", () => {
                window.location.href = "" + row.children[0].children[0].getAttribute("href");
            });
            row.
        }
    }
    */
}

);

