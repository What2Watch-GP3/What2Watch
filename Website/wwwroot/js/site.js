////// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
////// for details on configuring this project to bundle and minify static web assets.

////// Write your JavaScript code.
//////Do some Ajax load of movies
//////Update total price and seats count
////function updateSelectedCount() {
////    const selectedSeats = document.querySelectorAll('.row .seat.selected');
////    const selectedSeatsCount = selectedSeats.length;
////    count.innerText = selectedSeatsCount;
////    /* total.innerText = selectedSeatsCount * ticketPrice;*/
////}
////$(document).ready(function () {
////    //defining constants for the seat page
////    const container = document.querySelector('.container');
////    const seats = document.querySelectorAll('.row .seat:not(.occupied)');
////    const count = document.getElementById('count');
////    const total = document.getElementById('total');

////    /*let ticketPrice = +movieSelect.value;*/

////    //Seat click event
////    container.addEventListener('click', e => {
////        if (e.target.classList.contains('seat') &&
////            !e.target.classList.contains('occupied')) {
////            e.target.classList.toggle('selected');
////        }
////        updateSelectedCount();
////    });

////    //potential code for making the whole table row clickable, not just the movie name.
////    /*$("#search-test").on("keyup", function () {
////        var value = $(this).val().toLowerCase();
////        $("#movies-table tr").filter(function () {
////            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
////        });
////    });

////    //grabs the movie table and the a href from the table cell and applies it to the whole cell.
////    */
////    //if (document.getElementsByClassName("clickable-table") != null)
////    //{
////    //    const rows = document.getElementsByClassName("clickable-table")[0].children;
////    //    for (let i = 0; i < rows.length; i++) {
////    //        const row = rows[i];

////    //        row.addEventListener("click", () => {
////    //            window.location.href = "" + row.children[0].children[0].getAttribute("href");
////    //        });

////    //    }
////    //}
    
////}

   
    



////);  uncommented for now until selecting is fixed

const container = document.querySelector('.container');

//Seat click event
container.addEventListener('click', e => {
    if (e.target.classList.contains('seat') && !e.target.classList.contains('occupied')) {
        e.target.classList.toggle('selected');
    }
});


