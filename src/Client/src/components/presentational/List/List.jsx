import React from "react";
import PropTypes from "prop-types";

const List = (props) => (
    <div className="lists">
        <ul className={"nes-list " + props.type}>
            {props.items.map((item, index) =>
                <li key={index}>{item}</li>
            )}
        </ul>
    </div>
);

List.types = {
    DISC: "is-disc",
    CIRCLE: "is-circle",
}

List.propTypes = {
    type: PropTypes.oneOf(Object.values(List.types)).isRequired,
    items: PropTypes.arrayOf(PropTypes.string).isRequired
};

export default List;