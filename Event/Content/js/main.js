document.getElementById("delete").addEventListener('click', DeletePost);

function DeletePost(e) {
    var url = `/Event/Delete/${e.target.getAttribute('data_id')}`;
    var xhr = new XMLHttpRequest();
    xhr.open("Delete", url, true);
    xhr.onload = function() {
        if (xhr.readyState = 4 && xhr.status == "200") {
            window.location.href = "/Home/Index";
        }

    }

}