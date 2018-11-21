
function onCLickButton() {
    var text_to_be_inserted = "<<answer>>";
    var existing = document.getElementById("TextBox2").value;
    document.getElementById("TextBox2").value = existing+text_to_be_inserted;
}