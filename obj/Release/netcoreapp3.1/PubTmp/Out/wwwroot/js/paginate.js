function paginator(instance) {
    //  target  : html element to generate pagination.
    //  total   : total number of pages.
    //  click   : url string or function to call on click.
    //  current : (optional) current page, default 1.
    //  adj     : (optional) num of adjacent pages beside "current page", default 2.

    // (A) INIT & SET DEFAULTS
    if (instance.current === undefined) {
        let param = new URLSearchParams(window.location.search);
        instance.current = param.has("page") ? Number.parseInt(param.get("page")) : 1;
    }
    if (instance.adj === undefined) { instance.adj = 2; }
    if (instance.adj <= 0) { instance.adj = 1; }
    if (instance.current <= 0) { instance.current = 1; }
    if (instance.current > instance.total) { instance.current = instance.total; }

    // (B) URL STRING ONLY - DEAL WITH QUERY STRING & APPEND PG=N
    const jsmode = typeof instance.click == "function";
    if (jsmode == false) {
        if (instance.click.indexOf("?") == -1) { instance.click += "?page="; }
        else { instance.click += "&page="; }
    }

    // (C) HTML PAGINATION WRAPPER
    instance.target.innerHTML = "";
    instance.target.classList.add("paginate");

    // (D) DRAW PAGINATION SQUARES
    // (D1) HELPER FUNCTION TO DRAW PAGINATION SQUARE
    const square = (txt, pg, css) => {
        let el = document.createElement("a");
        el.innerHTML = txt;
        if (css) { el.className = css; }
        if (jsmode) { el.onclick = () => { instance.click(pg); }; }
        else { el.href = instance.click + pg; }
        instance.target.appendChild(el);
    };

    // (D2) BACK TO FIRST PAGE (DRAW ONLY IF SUFFICIENT SQUARES)
    if (instance.current - instance.adj > 1) { square("&#10218;", 1, "first"); }

    // (D3) ADJACENT SQUARES BEFORE CURRENT PAGE
    let temp;
    if (instance.current > 1) {
        temp = instance.current - instance.adj;
        if (temp <= 0) { temp = 1; }
        for (let i = temp; i < instance.current; i++) { square(i, i); }
    }

    // (D4) CURRENT PAGE
    square(instance.current, instance.current, "current");

    // (D5) ADJACENT SQUARES AFTER CURRENT PAGE
    if (instance.current < instance.total) {
        temp = instance.current + instance.adj;
        if (temp > instance.total) { temp = instance.total; }
        for (let i = instance.current + 1; i <= temp; i++) { square(i, i); }
    }

    // (D6) SKIP TO LAST PAGE (DRAW ONLY IF SUFFICIENT SQUARES)
    if (instance.current <= instance.total - instance.adj - 1) {
        square("&#10219;", instance.total, "last");
    }
}
