import React from "react";
import PropTypes from "prop-types";

const Table = (props) => (
    <div className="nes-table-responsive">
        <table className="nes-table is-bordered is-centered">
            <thead>
                <tr>
                    {props.headers
                        ? props.headers.map((header, index) =>
                            <th key={index}>{header}</th>
                        )
                        : null
                    }
                </tr>
            </thead>
            <tbody>
                {props.rows
                    ? props.rows.map((row, index) =>
                        <tr key={index}>
                            {row.map((item, index) =>
                                <td key={index}>{item}</td>
                            )}
                        </tr>
                    )
                    : null
                }
            </tbody>
        </table>
    </div>
);

Table.propTypes = {
    rows: PropTypes.arrayOf(PropTypes.array.isRequired),
    headers: PropTypes.array
};

export default Table;