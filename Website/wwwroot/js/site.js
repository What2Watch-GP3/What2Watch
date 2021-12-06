// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Do some Ajax load of movies
//Update total price and seats count

$(document).ready(function () {
    const container = document.querySelector('.seat-container');

    //Seat click event
    if (container != null)
    {
        container.addEventListener('click', e => {
            if (e.target.classList.contains('seat') && !e.target.classList.contains('occupied')) {
                e.target.classList.toggle('selected');
                if (document.querySelectorAll('.row .seat.selected').length <= 8)
                {
                    updateSelectedCount();
                }
                else
                {
                    e.target.classList.toggle('selected');
                    alert('you mofo thats enough of fucking seats okay');
                }
            }
        });
    }

    function updateSelectedCount() {
        const numberOfSeats = document.querySelectorAll('.row .seat.selected').length;

        countSpan.innerText = numberOfSeats;
    }

   
    
   // potential code for making the whole table row clickable, not just the movie name.
    //$("#search-test").on("keyup", function () {
    //    var value = $(this).val().toLowerCase();
    //    $("#movies-table tr").filter(function () {
    //        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    //    });
    //});

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




