function getSelectedLocation() {
    const select = document.getElementById('location');
    let locationId = event.target.value;
    var url = "Create?locationId=" + locationId;
    window.location.href = url;    
}

