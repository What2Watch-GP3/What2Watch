// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// TODO: remove what's not needed
// Write your JavaScript code.
//Do some Ajax load of movies
//Update total price and seats count


// Event for form submition with id #`form`
// Goes trough all rows, then seats that are selected and adds a hidden input with
// the id of that seat as value. This way te form submition can see them and add them as well
$("#form").submit(function (eventObj) {
    let index = 0;
    document.querySelectorAll('.row .seat.selected').forEach(seat => {
        // This line adds the hidden inputs
        // the name is important. It's used to map it to what the c# Action recives
        // It looks like selectedSeats[0] because `selectedSeats` is a List<string> as
        // parameter on the Action
        $(this).append('<input type="hidden" name="selectedSeats[' + index + ']" value="' + seat.id + '" /> ');
        index++;
    });
    return true;
});

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

    // Updates the selected seats <p> and increased the numberOfSeats count
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




