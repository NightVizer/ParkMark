import { useId } from 'react'
import type { ComponentPropsWithoutRef } from 'react'

import styles from './TextField.module.scss'

type TextFieldProps = ComponentPropsWithoutRef<'input'> & {
  label: string
  error?: string
}

export function TextField({
  label,
  error,
  className = '',
  id,
  'aria-describedby': describedBy,
  ...props
}: TextFieldProps) {
  const generatedId = useId()
  const inputId = id ?? generatedId
  const errorId = `${inputId}-error`
  return (
    <div className={styles.field}>
      <label className={styles.label} htmlFor={inputId}>
        {label}
      </label>
      <input
        {...props}
        id={inputId}
        className={`${styles.input} ${className}`}
        aria-invalid={error ? true : undefined}
        aria-describedby={
          [describedBy, error ? errorId : undefined].filter(Boolean).join(' ') || undefined
        }
      />
      {error && (
        <span id={errorId} className={styles.error}>
          {error}
        </span>
      )}
    </div>
  )
}
