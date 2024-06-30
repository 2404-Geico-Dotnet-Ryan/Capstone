import React from 'react'

function GoalsComponent() {
  return (
    <>
    <form>
      <div>
        <label htmlFor="reviewYear">Select Review Year:</label>
        <select id="year" name="year">
          <option value="2024">2024</option>
          <option value="2023">2023</option>
          <option value="2022">2022</option>
        </select>
      </div>

      <div>
        <button type="submit">Submit</button>
      </div>
    </form>
  </>
  )
}

export default GoalsComponent