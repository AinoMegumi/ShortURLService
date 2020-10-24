// License: Boost Software License 1.0
// See https://www.boost.org/LICENSE_1_0.txt
// Copyright © 2019 yumetodo <yume-wikijp@live.jp>

(function () {
    //header.append("Content-Length", "0");
    function ready(loaded) {
        if (['interactive', 'complete'].includes(document.readyState)) {
            loaded();
        } else {
            document.addEventListener('DOMContentLoaded', loaded);
        }
    }
    fetch("../config/redirect.json")
        .then(r => r.json()).then(response => {
            const items = response["redirects"].map(r => m("section", { "class": "box" }, [
                (("image" in r) ? m("img", { "src": `./pic/${r["image"]}` }) : m("div", { "class": "noimage" })),
                m("a", { "href": `./profile/${r["id"]}` }, m("article", { "class": "title" }, (Array.isArray(r["name"])) ? r["name"].map(mu => m("p", mu)) : m("p", r["name"])))
            ]));
            ready(() => {
                m.mount(document.getElementById("services"), { view: () => m("div", { "class": "main_container" }, items) });
            })
        })
        .catch(reason => {
            ready(() => {
                document.getElementById("services").innerText = reason.toString();
            })
        })
})();