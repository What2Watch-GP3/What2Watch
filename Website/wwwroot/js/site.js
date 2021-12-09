// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {

    //grabs the movie table and the a href from the table cell and applies it to the whole cell.
    
    if (document.getElementsByClassName("clickable-table") != null)
    {
        const rows = document.getElementsByClassName("clickable-table")[0].children;
        for (let i = 0; i < rows.length; i++) {
            const row = rows[i];

            row.addEventListener("click", () => {
                window.location.href = "" + row.children[0].children[0].getAttribute("href");
            });

        }
    } 
}
); 




