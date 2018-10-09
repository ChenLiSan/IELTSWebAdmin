
function incrementCount() {
    document.frm.count.value = parseInt(document.frm.count.value) + 1;
    addTextBox();
}

function decCount() {
    document.frm.count.value = parseInt(document.frm.count.value) - 1;
    removeTextBox();
}

function addTextBox() {
    var form = document.frm;
    form.appendChild(document.createElement('div')).innerHTML = "<table width=\\"40 %\\">"
        + "<tr><td>Name</td><td><input type=\\"text\\" name=\\"txt\\"></td></tr>"
            + "</table>";
}

function removeTextBox() {
    var form = document.frm;
    if (form.lastChild.nodeName.toLowerCase() == 'div')
        form.removeChild(form.lastChild);
}
