window.sortTableByStatus = function (tableId) {
    const table = document.getElementById(tableId);
    if (!table) return;

    const tbody = table.querySelector("tbody");
    if (!tbody) return;

    const rows = Array.from(tbody.querySelectorAll("tr[data-status]"));
    let isAsc = table.getAttribute("data-sort-asc") === "true";

    rows.sort((a, b) => {
        const aVal = parseInt(a.getAttribute("data-status"));
        const bVal = parseInt(b.getAttribute("data-status"));
        return isAsc ? (aVal - bVal) : (bVal - aVal);
    });

    rows.forEach(row => tbody.appendChild(row));
    table.setAttribute("data-sort-asc", !isAsc);

    const icon = table.querySelector("th[onclick*='" + tableId + "'] i");
    if (icon) {
        icon.className = isAsc ? "fa fa-sort-amount-desc text-primary" : "fa fa-sort-amount-asc text-primary";
    }
};