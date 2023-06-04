import { useEffect, useState } from "react";
import { Book } from "../components/entities/Book";

const useFetch = (url: string) => {
    /* const [data, setData] = useState<Book[]>([]);
    useEffect(() => {
        fetch(url).then((res) => res.json()).then((data) => setData(data));
    }, []);
    return data; */
};

export default useFetch;