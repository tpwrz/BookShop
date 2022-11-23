import { useEffect, useState } from "react";
import { Book } from "./entities/Book";

const useFetch = (url: string) => {
    const [data, setData] = useState<Book[]>([]);
    useEffect(() => {
        fetch(url).then((res) => res.json()).then((data) => setData(data));
    }, []);

};

export default useFetch;